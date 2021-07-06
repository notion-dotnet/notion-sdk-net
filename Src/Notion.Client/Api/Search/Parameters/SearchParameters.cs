﻿namespace Notion.Client
{
    public class SearchParameters : ISearchBodyParameters
    {
        public string Query { get; set; }
        public SearchSort Sort { get; set; }
        public SearchFilter Filter { get; set; }
        public string StartCursor { get; set; }
        public string PageSize { get; set; }
    }
}
