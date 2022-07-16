using Contacts.Core.Entities;

namespace Contacts.Core.Interfaces
{
    public interface IRepository<T, ID> where T : BaseEntity 
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(ID id);
        Task <bool> ExistsById(ID id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(ID id);
    }
}
