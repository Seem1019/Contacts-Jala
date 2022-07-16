using Contacts.Core.QueryFilters;
using Contacts.Infrastructure.Interfaces;

namespace Contacts.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetContactPaginationUri(ContactQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
