using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(JalaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contact>> GetAll(long id)
        {
            return await _entities.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<Contact> FindByEmail(string email)
        {
            return await _entities.Where(x=> x.Email== email).FirstOrDefaultAsync();
        }

        public async Task<Contact> FindByName(string name)
        {
            return await _entities.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
