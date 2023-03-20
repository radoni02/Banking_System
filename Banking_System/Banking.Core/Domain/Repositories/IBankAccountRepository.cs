using Banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Repositories
{
    public interface IBankAccountRepository
    {
        Task AddAsync(BankAccount account);
        Task UpdateAsync(BankAccount account);
        Task DeleteAsync(BankAccount account);
        Task<User> GetAsync(Guid id);
    }
}
