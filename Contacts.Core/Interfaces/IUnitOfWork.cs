using Contacts.Core.Entities;

namespace Contacts.Core.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IContactRepository ContactRepository { get; }

        IUserRepository UserRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        IRepository<Message, long> MessageRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }

}
