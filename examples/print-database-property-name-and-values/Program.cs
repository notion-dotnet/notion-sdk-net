using Notion.Client;

var client = new NotionClient(new ClientOptions
{
    AuthToken = "<Token>"
});

var databasesQueryParameters = new DatabasesQueryParameters();
var databaseId = "";
var queryResult = await client.Databases.QueryAsync(databaseId, databasesQueryParameters);

foreach (var result in queryResult.Results)
{
    Console.WriteLine("Page Id: " + result.Id);
    foreach (var property in result.Properties)
    {
        Console.WriteLine(property.Key + " " + GetValue(property.Value));
    }
}

object GetValue(PropertyValue p)
{
    switch (p)
    {
        case RichTextPropertyValue richTextPropertyValue:
            return richTextPropertyValue.RichText.FirstOrDefault()?.PlainText;
        default:
            return null;
    }
}