using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// The type of a typed database (and of the data sources inside it); <c>null</c> for a regular database.
    /// Creating a database only accepts <see cref="Tasks" />, <see cref="Projects" /> and <see cref="Skills" />.
    /// New values introduced by Notion are preserved as-is rather than causing a deserialization failure.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<DatabaseType>))]
    public readonly struct DatabaseType : IEquatable<DatabaseType>
    {
        private readonly string _value;

        public DatabaseType(string value) => _value = value;

        public const string TasksValue = "tasks";
        public const string ProjectsValue = "projects";
        public const string SprintsValue = "sprints";
        public const string DocsValue = "docs";
        public const string WikiValue = "wiki";
        public const string MeetingsValue = "meetings";
        public const string MeetingNotesValue = "meeting_notes";
        public const string SkillsValue = "skills";
        public const string GithubPrsValue = "github_prs";

        public static readonly DatabaseType Tasks = new DatabaseType(TasksValue);
        public static readonly DatabaseType Projects = new DatabaseType(ProjectsValue);
        public static readonly DatabaseType Sprints = new DatabaseType(SprintsValue);
        public static readonly DatabaseType Docs = new DatabaseType(DocsValue);
        public static readonly DatabaseType Wiki = new DatabaseType(WikiValue);
        public static readonly DatabaseType Meetings = new DatabaseType(MeetingsValue);
        public static readonly DatabaseType MeetingNotes = new DatabaseType(MeetingNotesValue);
        public static readonly DatabaseType Skills = new DatabaseType(SkillsValue);
        public static readonly DatabaseType GithubPrs = new DatabaseType(GithubPrsValue);

        public static implicit operator DatabaseType(string value) => new DatabaseType(value);

        public static bool operator ==(DatabaseType left, DatabaseType right) => left.Equals(right);
        public static bool operator !=(DatabaseType left, DatabaseType right) => !left.Equals(right);

        public bool Equals(DatabaseType other) =>
            string.Equals(_value, other._value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is DatabaseType other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value ?? string.Empty;
    }
}
