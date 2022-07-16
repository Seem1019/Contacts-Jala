using Contacts.Core.CustomEntities;
using Contacts.Core.Entities;
using Contacts.Core.QueryFilters;

namespace Contacts.Core.Interfaces
{
    public interface IContactService
    {
        PagedList<Contact> GetContacts(ContactQueryFilter filters);

        Task<Contact> GetContact(int id);
        Task<Contact> GetContactByName(string name);
        Task<Contact> GetContactByEmail(string email);
        Task InsertContact(Contact post);

        Task<bool> UpdateContact(Contact post);

        Task<bool> DeleteContact(int id);
    }
}
