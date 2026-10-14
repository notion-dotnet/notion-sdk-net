namespace Notion.Client
{
    /// <summary>
    /// Fallback payload type for webhook events with an unrecognized "type" value.
    /// The raw type string is accessible via <see cref="WebhookPayload.Type"/>.
    /// </summary>
    public class UnknownWebhookPayload : WebhookPayload
    {
    }
}
