using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion.Client.Extensions
{
    public static class QualityOfLifeExtensions
    {
        public static (string Key, TitlePropertyValue Value) GetTitleProperty(this Page page)
        {
            var keyValuePair = page.Properties.First(x =>
                x.Value.Type == PropertyValueType.Title);
            return (
                Key: keyValuePair.Key, 
                Value: (TitlePropertyValue) keyValuePair.Value);
        }

        public static string GetAllPlainText(this TitlePropertyValue titlePropertyValue)
        {
            if (titlePropertyValue.Title.Count == 1) // to save some efficiency with most common case
                return titlePropertyValue.Title[0].PlainText;

            var str = new StringBuilder();
            foreach (var richTextBase in titlePropertyValue.Title)
                str.Append(richTextBase.PlainText);

            return str.ToString();
        }

        public static async Task QueryToEndAsync(this IDatabasesClient databasesClient,
            string databaseId, DatabasesQueryParameters databasesQueryParameters, Action<List<Page>> onPartReceived)
        {
            databasesQueryParameters = databasesQueryParameters.CreateCopy();
            List<List<Page>> results = new List<List<Page>>(1);

            while (true)
            {
                var paginatedList = await databasesClient.QueryAsync(databaseId, databasesQueryParameters);
                results.Add(paginatedList.Results);

                if (!paginatedList.HasMore) break;

                onPartReceived.Invoke(paginatedList.Results);
                databasesQueryParameters.StartCursor = paginatedList.NextCursor;
            }
        }
    }
}