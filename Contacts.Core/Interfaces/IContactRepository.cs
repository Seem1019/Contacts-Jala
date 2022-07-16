using Contacts.Core.Entities;

namespace Contacts.Core.Interfaces
{
    public interface IContactRepository: IRepository<Contact, long>
    {
        Task<Contact> FindByEmail(string email);
        Task<Contact> FindByName(string name);
        Task<IEnumerable<Contact>> GetAll(long id);
    }
}
