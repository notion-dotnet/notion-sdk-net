using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class Page
    {
        public string Object => "page";
        public string Id { get; set; }
        public Parent Parent { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }

        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        private IDictionary<string, PropertyValue> _properties;
        public IDictionary<string, PropertyValue> Properties
        {
            get => _properties;
            set
            {
                _titlePropertyValue = null;
                _properties = value;
            }
        }

        private string _titlePropertyKey;
        private TitlePropertyValue _titlePropertyValue;
        public TitlePropertyValue Title
        {
            get
            {
                if (_titlePropertyKey == null)
                {
                    var titleProperty = Properties.First(x =>
                        x.Value.Type == PropertyValueType.Title);
                    _titlePropertyKey = titleProperty.Key;
                    _titlePropertyValue = (TitlePropertyValue) titleProperty.Value;
                }
                return _titlePropertyValue;
            }
            set
            {
                if (_titlePropertyKey == null)
                    _titlePropertyKey = Properties.First(x => x.Value.Type == PropertyValueType.Title).Key;
                    
                Properties[_titlePropertyKey] = value;
                _titlePropertyValue = value;
            }
        }
    }
}
