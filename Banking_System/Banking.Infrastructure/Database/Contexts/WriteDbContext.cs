using Banking.Core.Domain.Entities;
using Banking.Core.Domain.ValueObjects;
using Banking.Infrastructure.Database.EntityConfiguration.WriteConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Banking System");
            var bankAccountConfiguration = new BankAccountConfiguration();
            var userConfiguration = new UserConfiguration();
            modelBuilder.ApplyConfiguration<BankAccount>(bankAccountConfiguration);
            modelBuilder.ApplyConfiguration<User>(userConfiguration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
