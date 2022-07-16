using Contacts.Core.Entities;

namespace Contacts.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security, long>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task<Security>GetUserByUsername(string username);
    }
}
