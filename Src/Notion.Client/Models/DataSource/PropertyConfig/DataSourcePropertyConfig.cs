using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CheckboxDataSourcePropertyConfig), DataSourcePropertyTypes.Checkbox)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedByDataSourcePropertyConfig), DataSourcePropertyTypes.CreatedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(CreatedTimeDataSourcePropertyConfig), DataSourcePropertyTypes.CreatedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(DateDataSourcePropertyConfig), DataSourcePropertyTypes.Date)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(EmailDataSourcePropertyConfig), DataSourcePropertyTypes.Email)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FilesDataSourcePropertyConfig), DataSourcePropertyTypes.Files)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(FormulaDataSourcePropertyConfig), DataSourcePropertyTypes.Formula)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedByDataSourcePropertyConfig), DataSourcePropertyTypes.LastEditedBy)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(LastEditedTimeDataSourcePropertyConfig), DataSourcePropertyTypes.LastEditedTime)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(MultiSelectDataSourcePropertyConfig), DataSourcePropertyTypes.MultiSelect)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(NumberDataSourcePropertyConfig), DataSourcePropertyTypes.Number)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PeopleDataSourcePropertyConfig), DataSourcePropertyTypes.People)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(PhoneNumberDataSourcePropertyConfig), DataSourcePropertyTypes.PhoneNumber)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RelationDataSourcePropertyConfig), DataSourcePropertyTypes.Relation)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RichTextDataSourcePropertyConfig), DataSourcePropertyTypes.RichText)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(RollupDataSourcePropertyConfig), DataSourcePropertyTypes.Rollup)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(SelectDataSourcePropertyConfig), DataSourcePropertyTypes.Select)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(StatusDataSourcePropertyConfig), DataSourcePropertyTypes.Status)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(TitleDataSourcePropertyConfig), DataSourcePropertyTypes.Title)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UrlDataSourcePropertyConfig), DataSourcePropertyTypes.Url)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(UniqueIdDataSourcePropertyConfig), DataSourcePropertyTypes.UniqueId)]
    [JsonSubtypes.KnownSubTypeAttribute(typeof(ButtonDataSourcePropertyConfig), DataSourcePropertyTypes.Button)]
    public class DataSourcePropertyConfig
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
