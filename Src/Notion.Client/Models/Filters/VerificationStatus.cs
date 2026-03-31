using System.Runtime.Serialization;

namespace Notion.Client
{
    /// <summary>
    /// Verification status values.
    /// </summary>
    public enum VerificationStatus
    {
        [EnumMember(Value = "verified")]
        Verified,

        [EnumMember(Value = "expired")]
        Expired,

        [EnumMember(Value = "none")]
        None
    }
}
