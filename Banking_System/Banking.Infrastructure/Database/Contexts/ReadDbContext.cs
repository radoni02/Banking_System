using Banking.Infrastructure.Database.EntityConfiguration.ReadConfig;
using Banking.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<UserReadModel> Users { get; set; }
        public DbSet<BankAccountReadModel> BankAccounts { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Banking System");
            var bankAccountConfiguration = new BankAccountConfiguration();
            var userConfiguration = new UserConfiguration();
            modelBuilder.ApplyConfiguration<BankAccountReadModel>(bankAccountConfiguration);
            modelBuilder.ApplyConfiguration<UserReadModel>(userConfiguration);
            base.OnModelCreating(modelBuilder);
        }
    }
}
