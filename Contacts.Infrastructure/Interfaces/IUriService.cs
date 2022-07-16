using Contacts.Core.QueryFilters;

namespace Contacts.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetContactPaginationUri(ContactQueryFilter filter, string actionUrl);
    }
}
