using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Notion.Client
{
    public interface IPagesClient
    {
        /// <summary>
        ///     Creates a new page in the specified database or as a child of an existing page.
        ///     If the parent is a database, the
        ///     <see href="https://developers.notion.com/reference-link/page#property-value-object">property values</see> of the
        ///     new page in the properties parameter must conform to the parent
        ///     <see href="https://developers.notion.com/reference-link/database">database</see>'s property schema.
        ///     If the parent is a page, the only valid property is <strong>title</strong>.
        /// </summary>
        /// <param name="pagesCreateParameters">Create page parameters</param>
        /// <returns>Created <see cref="Page" /> object.</returns>
        Task<Page> CreateAsync(PagesCreateParameters pagesCreateParameters, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Retrieves a Page object using the ID specified.
        /// </summary>
        /// <param name="pageId">Identifier for a Notion page</param>
        /// <returns>
        ///     <see cref="Page" />
        /// </returns>
        Task<Page> RetrieveAsync(string pageId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates page property values for the specified page.
        ///     Note: Properties that are not set via the properties parameter will remain unchanged.
        /// </summary>
        /// <param name="pageId">Identifier for a Notion page</param>
        /// <param name="updatedProperties">
        ///     Property values to update for this page. The keys are the names or IDs of the property
        ///     and the values are property values.
        /// </param>
        /// <returns>Updated <see cref="Page" /> object</returns>
        Task<Page> UpdatePropertiesAsync(
            string pageId,
            IDictionary<string, PropertyValue> updatedProperties, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Updates page property values for the specified page.
        ///     Properties that are not set via the properties parameter will remain unchanged.
        /// </summary>
        /// <param name="pageId">Identifier for a Notion page</param>
        /// <param name="pagesUpdateParameters">Update property parameters</param>
        /// <returns>Updated <see cref="Page" /> object</returns>
        Task<Page> UpdateAsync(string pageId, PagesUpdateParameters pagesUpdateParameters, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Retrieves a property_item object for a given pageId and propertyId. Depending on the property type, the object
        ///     returned will either be a value or a paginated list of property item values.
        /// </summary>
        /// <param name="retrievePropertyItemParameters">Property body and query parameters</param>
        /// <returns>
        ///     <see cref="IPropertyItemObject" />
        /// </returns>
        Task<IPropertyItemObject> RetrievePagePropertyItemAsync(
            RetrievePropertyItemParameters retrievePropertyItemParameters, CancellationToken cancellationToken = default);
    }
}
