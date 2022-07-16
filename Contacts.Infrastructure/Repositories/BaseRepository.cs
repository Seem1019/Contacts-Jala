using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T, long> where T : BaseEntity
    {
        private readonly JalaContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(JalaContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(long id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(long id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        public async Task<bool> ExistsById(long id)
        {
            return await _entities.FindAsync(id) != null;
        }
    }
}
