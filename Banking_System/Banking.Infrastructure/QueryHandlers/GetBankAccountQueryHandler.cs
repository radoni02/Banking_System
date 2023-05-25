using Banking.Application.Dto;
using Banking.Application.Queries;
using Banking.Infrastructure.Database.Contexts;
using Banking.Infrastructure.Database.Models;
using Banking.Infrastructure.QueryHandlers.Mapper;
using Convey.CQRS.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.QueryHandlers
{
    internal sealed class GetBankAccountQueryHandler : IQueryHandler<GetBankAccountQuery, BankAccountDto>
    {
        private readonly DbSet<BankAccountReadModel> _bankAccounts;

        public GetBankAccountQueryHandler(ReadDbContext context)
        {
            _bankAccounts = context.BankAccounts;
        }

        public async Task<BankAccountDto> HandleAsync(GetBankAccountQuery query, CancellationToken cancellationToken = default)
        {
            return await _bankAccounts
                .Where(a => a.Id == query.AccountId)
                .Include(i => i.Transfers)
                .Select(x => x.AsDto())
                .FirstOrDefaultAsync();
                
        }
    }
}
