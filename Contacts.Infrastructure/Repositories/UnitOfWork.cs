using Contacts.Core.Entities;
using Contacts.Core.Interfaces;
using Contacts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JalaContext _context;
        private readonly IRepository<Message, long> _messageRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(JalaContext context)
        {
            _context = context;
        }

        public IContactRepository ContactRepository => _contactRepository ?? new ContactRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new  UserRepository(_context);
        public IRepository<Message,long> MessageRepository => _messageRepository ?? new BaseRepository<Message>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
