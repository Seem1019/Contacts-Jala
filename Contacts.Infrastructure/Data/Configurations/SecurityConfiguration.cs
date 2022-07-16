using Contacts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {

            builder.ToTable("Security");
            builder.HasKey(e => e.Id);



            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);


            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithOne(p => p.Security)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Security_User");

        }
    }
}
