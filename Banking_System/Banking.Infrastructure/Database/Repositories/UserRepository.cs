using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Repositories;
using Banking.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly WriteDbContext _writeDbContext;

        public UserRepository(WriteDbContext writeDbContext)
        {
            _users = writeDbContext.Users;
            _writeDbContext = writeDbContext;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(Guid id)
            => await _users.AnyAsync(x => x.Id == id);

        public async Task<User> GetAsync(Guid id)
            => await _users.Include(x => x.Accounts)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
