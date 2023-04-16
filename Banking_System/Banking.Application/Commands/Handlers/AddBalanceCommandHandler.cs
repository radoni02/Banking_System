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
    public class AddBalanceCommandHandler : ICommandHandler<AddBalanceCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public AddBalanceCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(AddBalanceCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.OwnerId);
            if(user is null)
            {
                throw new UserNotFoundException(command.OwnerId);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Type == command.Type);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            account.AddBalanceToAccount(command.Currency,command.Type);
            await _bankAccountRepository.UpdateAsync(account);


        }
    }
}
