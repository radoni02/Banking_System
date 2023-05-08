using Banking.Core.Domain.Entities;
using Banking.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.EntityConfiguration.WriteConfig
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(true);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnName("Lastname")
                .HasMaxLength(64)
                .IsUnicode(true);

            //builder.Property(u => u.Pesel).HasConversion(
            //    pesel => pesel.Value,
            //    value=>Pesel.Create(value));

            builder.Property(u=>u.PhoneNumber).HasConversion(
                phoneNumber=>phoneNumber.Value,
                value=>PhoneNumber.Create(value))
                .IsRequired()
                .HasColumnName("Phone number")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(u => u.EmailAddress).HasConversion(
                emailAddress => emailAddress.Value,
                value => EmailAddress.Create(value))
                .IsRequired()
                .HasColumnName("Email address")
                .IsUnicode(true);
            builder.HasIndex(u => u.EmailAddress).IsUnique();

            builder.HasMany(u => u.Accounts)
                .WithMany();

        }
    }
}
