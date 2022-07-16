using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Infrastructure.Data;

namespace Contacts.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JalaContext context) : base(context)
        {
        }

        public async Task<User> FindByCodeAsync(string code)
        {
            return await _entities.FindAsync(code);
        }
    }
}
