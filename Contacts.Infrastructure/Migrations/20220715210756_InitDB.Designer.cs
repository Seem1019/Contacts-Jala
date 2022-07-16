﻿// <auto-generated />
using System;
using Contacts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contacts.Infrastructure.Migrations
{
    [DbContext(typeof(JalaContext))]
    [Migration("20220715210756_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Contacts.Core.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("Contacts.Core.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ContactId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Contacts.Core.Entities.Security", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<long>("UserId")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Security", (string)null);
                });

            modelBuilder.Entity("Contacts.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Contacts.Core.Entities.Contact", b =>
                {
                    b.HasOne("Contacts.Core.Entities.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Contacts_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contacts.Core.Entities.Message", b =>
                {
                    b.HasOne("Contacts.Core.Entities.Contact", "Contact")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Messages_Contact");

                    b.HasOne("Contacts.Core.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Messages_User");

                    b.Navigation("Contact");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contacts.Core.Entities.Security", b =>
                {
                    b.HasOne("Contacts.Core.Entities.User", "User")
                        .WithOne("Security")
                        .HasForeignKey("Contacts.Core.Entities.Security", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Security_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Contacts.Core.Entities.Contact", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Contacts.Core.Entities.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Messages");

                    b.Navigation("Security")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
