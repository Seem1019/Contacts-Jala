using Contacts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Contacts.Infrastructure.Data
{
    public partial class JalaContext :DbContext
    {
        public JalaContext(){}
        public JalaContext(DbContextOptions<JalaContext> options):base(options){}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
