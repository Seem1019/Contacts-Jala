using Contacts.Core.Entities;

namespace Contacts.Core.Interfaces
{
    public interface IUserRepository:IRepository<User, long>
    {
        Task<User>  FindByCodeAsync(string code);
    }
}
