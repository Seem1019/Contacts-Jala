using Contacts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(e => e.Id);


            builder.Property(e => e.UserId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacts_User");

        }
    }
}
