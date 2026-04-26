using Newtonsoft.Json;

public interface IRetrievePageAsMarkdownQueryParameters
{
    /// <summary>
    /// Whether to include meeting note transcripts. Defaults to false. 
    /// When true, full transcripts are included; 
    /// when false, a placeholder with the meeting note URL is shown instead.
    /// </summary>
    [JsonProperty("include_transcript")]
    bool IncludeTranscript { get; set; }
}
