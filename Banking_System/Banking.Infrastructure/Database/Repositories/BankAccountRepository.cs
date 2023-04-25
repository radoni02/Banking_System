using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Repositories;
using Banking.Core.Domain.ValueObjects;
using Banking.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Repositories
{
    internal sealed class BankAccountRepository : IBankAccountRepository
    {
        private readonly DbSet<BankAccount> _bankAccounts;
        private readonly WriteDbContext _writeDbContext;

        public BankAccountRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _bankAccounts = writeDbContext.BankAccounts;
        }

        public async Task AddAsync(BankAccount account)
        {
            await _bankAccounts.AddAsync(account);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BankAccount account)
        {
            _bankAccounts.Remove(account);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<BankAccount> GetAsync(Guid id)
        => await _bankAccounts
            .Include(x => x.AccountBalances)
            .Include(x => x.OwnersId)
            .Include(x => x.Transfers)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<BankAccount> GetByAccountNumberAsync(AccountNumber accountNumber)
            => await _bankAccounts
            .Include(x => x.AccountBalances)
            .Include(x => x.OwnersId)
            .Include(x => x.Transfers)
            .FirstOrDefaultAsync(x => x.AccountNumber.Value == accountNumber.Value);

        public async Task UpdateAsync(BankAccount account)
        {
            _bankAccounts.Update(account);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
