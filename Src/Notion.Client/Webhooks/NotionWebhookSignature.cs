using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Notion.Client
{
    /// <summary>
    /// Provides helpers for verifying and generating Notion webhook signatures.
    /// The signature is sent by Notion in the <c>X-Notion-Signature</c> header and
    /// follows the format <c>sha256=&lt;64-char-lowercase-hex&gt;</c>.
    /// </summary>
    public static class NotionWebhookSignature
    {
        private const string SignaturePrefix = "sha256=";

        /// <summary>
        /// Verifies that the given <paramref name="signature"/> matches the HMAC-SHA256 of
        /// <paramref name="body"/> keyed with <paramref name="verificationToken"/>.
        /// Returns <c>false</c> (never throws) for null or malformed input.
        /// </summary>
        /// <param name="body">The raw UTF-8 request body string.</param>
        /// <param name="signature">
        /// The value of the <c>X-Notion-Signature</c> header, e.g. <c>sha256=abc123…</c>.
        /// </param>
        /// <param name="verificationToken">The webhook verification token from Notion.</param>
        /// <returns><c>true</c> if the signature is valid; otherwise <c>false</c>.</returns>
        public static Task<bool> VerifySignatureAsync(string body, string signature, string verificationToken)
        {
            if (body == null)
            {
                return Task.FromResult(false);
            }

            byte[] bodyBytes;
            try
            {
                bodyBytes = Encoding.UTF8.GetBytes(body);
            }
            catch
            {
                return Task.FromResult(false);
            }

            return VerifySignatureAsync(bodyBytes, signature, verificationToken);
        }

        /// <summary>
        /// Verifies that the given <paramref name="signature"/> matches the HMAC-SHA256 of
        /// <paramref name="body"/> keyed with <paramref name="verificationToken"/>.
        /// Returns <c>false</c> (never throws) for null or malformed input.
        /// </summary>
        /// <param name="body">The raw request body bytes.</param>
        /// <param name="signature">
        /// The value of the <c>X-Notion-Signature</c> header, e.g. <c>sha256=abc123…</c>.
        /// </param>
        /// <param name="verificationToken">The webhook verification token from Notion.</param>
        /// <returns><c>true</c> if the signature is valid; otherwise <c>false</c>.</returns>
        public static Task<bool> VerifySignatureAsync(byte[] body, string signature, string verificationToken)
        {
            try
            {
                if (body == null || string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(verificationToken))
                {
                    return Task.FromResult(false);
                }

                if (!signature.StartsWith(SignaturePrefix, StringComparison.Ordinal))
                {
                    return Task.FromResult(false);
                }

                string providedHex = signature.Substring(SignaturePrefix.Length);

                // A SHA-256 hex digest is always exactly 64 characters.
                if (providedHex.Length != 64)
                {
                    return Task.FromResult(false);
                }

                string computedHex = ComputeHmacSha256Hex(body, verificationToken);
                bool valid = ConstantTimeEquals(computedHex, providedHex);
                return Task.FromResult(valid);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Computes the Notion webhook signature for <paramref name="body"/> using
        /// <paramref name="verificationToken"/>, returning a string of the form
        /// <c>sha256=&lt;hex&gt;</c>. Useful for testing webhook handlers locally.
        /// </summary>
        /// <param name="body">The raw UTF-8 request body string.</param>
        /// <param name="verificationToken">The webhook verification token from Notion.</param>
        /// <returns>A signature string of the form <c>sha256=&lt;hex&gt;</c>.</returns>
        public static Task<string> SignPayloadAsync(string body, string verificationToken)
        {
            if (body == null) throw new ArgumentNullException(nameof(body));
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            return SignPayloadAsync(bodyBytes, verificationToken);
        }

        /// <summary>
        /// Computes the Notion webhook signature for <paramref name="body"/> using
        /// <paramref name="verificationToken"/>, returning a string of the form
        /// <c>sha256=&lt;hex&gt;</c>. Useful for testing webhook handlers locally.
        /// </summary>
        /// <param name="body">The raw request body bytes.</param>
        /// <param name="verificationToken">The webhook verification token from Notion.</param>
        /// <returns>A signature string of the form <c>sha256=&lt;hex&gt;</c>.</returns>
        public static Task<string> SignPayloadAsync(byte[] body, string verificationToken)
        {
            if (body == null) throw new ArgumentNullException(nameof(body));
            if (string.IsNullOrEmpty(verificationToken)) throw new ArgumentNullException(nameof(verificationToken));

            string hex = ComputeHmacSha256Hex(body, verificationToken);
            return Task.FromResult(SignaturePrefix + hex);
        }

        // ── Private helpers ──────────────────────────────────────────────────────

        private static string ComputeHmacSha256Hex(byte[] body, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmac.ComputeHash(body);
                return BytesToHexLower(hash);
            }
        }

        private static string BytesToHexLower(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Compares two strings in constant time to prevent timing attacks.
        /// </summary>
        /// <remarks>
        /// <c>CryptographicOperations.FixedTimeEquals</c> is not available in
        /// netstandard2.0, so this method provides an equivalent implementation.
        /// </remarks>
        private static bool ConstantTimeEquals(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }

            return diff == 0;
        }
    }
}
