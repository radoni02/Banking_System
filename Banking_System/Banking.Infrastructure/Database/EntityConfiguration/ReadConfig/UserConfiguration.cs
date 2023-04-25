using Banking.Core.Domain.Consts;
using Banking.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Infrastructure.Database.EntityConfiguration.ReadConfig
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);

            builder.Property(u=>u.FirstName)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(true);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnName("Lastname")
                .HasMaxLength(64)
                .IsUnicode(true);

            //builder.Property(u => u.Gender)  
            //    .HasConversion(g => g.ToString(),
            //    g => Enum.Parse<Gender>(g));

            builder.Property(u => u.Pesel)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);
            builder.HasIndex(u => u.Pesel).IsUnique();

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasColumnName("Phone number")
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasColumnName("Email address")
                .IsUnicode(true);
            builder.HasIndex(u=>u.EmailAddress).IsUnique();

            builder.HasMany(u => u.Accounts)
                .WithMany();
                


        }
    }
}
