using Banking.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.EntityConfiguration.ReadConfig
{
    internal sealed class BankAccountConfiguration : IEntityTypeConfiguration<BankAccountReadModel>
    {
        public void Configure(EntityTypeBuilder<BankAccountReadModel> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.Card, cardBuilder =>
            {
                cardBuilder.Property(c => c.CVV).HasMaxLength(3).IsRequired();
                cardBuilder.Property(c=>c.CardHolderName).HasMaxLength(50).IsRequired();
                cardBuilder.Property(c => c.CardNumber).HasMaxLength(16).IsRequired();
                cardBuilder.HasIndex(c=>c.CardNumber).IsUnique();
            });

            builder.Property(a => a.Pin)
                .HasMaxLength(4)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(a => a.AccountNumber)
                .HasMaxLength(26)
                .IsRequired()
                .IsUnicode(false);
            builder.HasIndex(a => a.AccountNumber).IsUnique();

            builder.HasMany(a => a.Transfers)
                .WithMany();

            builder.HasMany(a => a.Balances)
                .WithOne();




        }
    }
}
