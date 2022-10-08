﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client
{
    public partial class CommentsClient
    {
        public async Task<RetrieveCommentsResponse> Retrieve(RetrieveCommentsParameters parameters)
        {
            var qp = (IRetrieveCommentsQueryParameters)parameters;

            var queryParams = new Dictionary<string, string>
            {
                { "block_id", qp.BlockId },
                { "start_cursor", qp.StartCursor },
                { "page_size", qp.PageSize.ToString() }
            };

            return await _client.GetAsync<RetrieveCommentsResponse>(
                ApiEndpoints.CommentsApiUrls.Retrieve(),
                queryParams
            );
        }
    }
}