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
    internal sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.Card, cardBuilder =>
            {
                cardBuilder.Property(c => c.CVV).HasMaxLength(3).IsRequired();
                cardBuilder.Property(c => c.CardHolderName).HasMaxLength(50).IsRequired();
                cardBuilder.Property(c => c.CardNumber).HasMaxLength(16).IsRequired();
                cardBuilder.HasIndex(c => c.CardNumber).IsUnique();
            });

            builder.Property(u => u.Pin).HasConversion(
                pin => pin.Value,
                value => Pin.Create(value))
                .HasMaxLength(4)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(u=>u.AccountNumber).HasConversion(
                accountNumber=>accountNumber.Value,
                value=>AccountNumber.Create(value))
                 .HasMaxLength(26)
                .IsRequired()
                .IsUnicode(false);
            builder.HasIndex(a => a.AccountNumber).IsUnique();

            builder.HasMany(a => a.Transfers)
                .WithOne()
                .HasForeignKey(t => t.SenderId)
                .HasForeignKey(t => t.ReciverId);

            builder.HasMany(a => a.AccountBalances)
                .WithOne()
                .HasForeignKey(b => b.Currency);
        }
    }
}
