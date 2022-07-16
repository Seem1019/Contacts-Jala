using Contacts.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");
            builder.HasKey(e => e.Id);


            builder.Property(e => e.UserId);
            builder.Property(e => e.ContactId);



            builder.HasOne(d => d.User)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_User");

            builder.HasOne(d => d.Contact)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Contact");



        }
    }

}
