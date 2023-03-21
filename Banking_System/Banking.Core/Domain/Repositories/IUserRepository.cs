using Banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> ExistByIdAsync(Guid id);
        Task<User> GetAsync(Guid id);
    }
}
