using Newtonsoft.Json;

namespace Notion.Client
{
    public interface ICreateTokenBodyParameters
    {
        /// <summary>
        /// A constant string: "authorization_code".
        /// </summary>
        [JsonProperty("grant_type")]
        string GrantType { get; }

        /// <summary>
        /// A unique random code that Notion generates to authenticate with your service,
        /// generated when a user initiates the OAuth flow.
        /// </summary>
        [JsonProperty("code")]
        string Code { get; set; }

        /// <summary>
        /// The "redirect_uri" that was provided in the OAuth Domain & URI section
        /// of the integration's Authorization settings. Do not include this field if a
        /// "redirect_uri" query param was not included in the Authorization URL
        /// provided to users. In most cases, this field is required.
        /// </summary>
        [JsonProperty("redirect_uri")]
        string RedirectUri { get; set; }

        /// <summary>
        /// External account details
        /// </summary>
        [JsonProperty("external_account")]
        ExternalAccount ExternalAccount { get; set; }
    }
}
