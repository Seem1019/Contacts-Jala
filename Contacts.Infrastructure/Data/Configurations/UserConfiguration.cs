using Contacts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


            builder.Property(e => e.IsActive);
        }
    }
}
