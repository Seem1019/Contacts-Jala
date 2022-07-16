using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(JalaContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == login.User);
        }

        public Task<Security> GetUserByUsername(string username)
        {
           return _entities.FirstOrDefaultAsync(x => x.UserName == username);
        }
    }
}
