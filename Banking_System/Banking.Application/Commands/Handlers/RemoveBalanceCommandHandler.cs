using Banking.Application.Exceptions;
using Banking.Core.Domain.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class RemoveBalanceCommandHandler : ICommandHandler<RemoveBalanceCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public RemoveBalanceCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(RemoveBalanceCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if(user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Type == Core.Domain.Consts.AccountType.ForeignExchangeAccount);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            account.RemoveBalanceFromAccount(command.Currency);
            await _bankAccountRepository.UpdateAsync(account);
        }
    }
}
