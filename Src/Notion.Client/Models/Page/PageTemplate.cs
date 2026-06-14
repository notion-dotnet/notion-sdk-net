using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Specifies a template to apply when creating or updating a page.
    /// </summary>
    public abstract class PageTemplate
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }

    /// <summary>
    /// Clears any template on the page (only valid for Create Page).
    /// </summary>
    public class NonePageTemplate : PageTemplate
    {
        public override string Type => "none";
    }

    /// <summary>
    /// Applies the default template associated with the parent database.
    /// </summary>
    public class DefaultPageTemplate : PageTemplate
    {
        public override string Type => "default";

        /// <summary>
        /// IANA timezone string used to resolve date/time variables in the template.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    /// <summary>
    /// Applies a specific template by its ID.
    /// </summary>
    public class TemplateIdPageTemplate : PageTemplate
    {
        public override string Type => "template_id";

        /// <summary>
        /// The ID of the template to apply.
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// IANA timezone string used to resolve date/time variables in the template.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
