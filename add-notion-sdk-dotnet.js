/**
 * ✨ Added Notion SDK for .NET – A simple and easy to use client for the Notion API
 * Provides integration with Notion’s API for .NET developers with simple initialization,
 * dependency injection, and database querying support.
 */

const notionSdkDotNet = {
  name: "Notion SDK for .NET",
  description:
    "A simple and easy to use client for the Notion API with support for dependency injection, database querying, and advanced filters.",
  language: ".NET / C#",
  features: [
    "Lightweight Notion API client",
    "Supports dependency injection",
    "Database querying and filtering",
    "Supports Databases, Pages, Blocks, Comments, Users, Search endpoints",
    "Internal logging via ILoggerFactory"
  ],
  install: {
    cli: "dotnet add package Notion.Net"
  },
  usageExample: `
var client = NotionClientFactory.Create(new ClientOptions {
    AuthToken = "<Token>"
});
var usersList = await client.Users.ListAsync();
  `,
  github: "https://github.com/dvcrn/notion.net",
  nuget: "https://www.nuget.org/packages/Notion.Net/",
  addedBy: "Shikhar Natani",
  addedOn: new Date().toISOString()
};

// Export for the PR
export default notionSdkDotNet;
