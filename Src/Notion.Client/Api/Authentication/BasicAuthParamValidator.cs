using System;

namespace Notion.Client
{
    public static class BasicAuthParamValidator
    {
        public static void Validate(IBasicAuthenticationParameters basicAuthParams)
        {
            if (basicAuthParams == null)
            {
                throw new ArgumentNullException(nameof(basicAuthParams), "Basic authentication parameters must be provided.");
            }

            if (string.IsNullOrWhiteSpace(basicAuthParams.ClientId))
            {
                throw new ArgumentException("ClientId must be provided.", nameof(basicAuthParams.ClientId));
            }

            if (string.IsNullOrWhiteSpace(basicAuthParams.ClientSecret))
            {
                throw new ArgumentException("ClientSecret must be provided.", nameof(basicAuthParams.ClientSecret));
            }
        }
    }
}
