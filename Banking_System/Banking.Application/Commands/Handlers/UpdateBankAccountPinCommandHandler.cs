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
    public class UpdateBankAccountPinCommandHandler : ICommandHandler<UpdateBankAccountPinCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public UpdateBankAccountPinCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(UpdateBankAccountPinCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.UserId);
            if(user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Id == command.AccountId);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            account.EnsureThatOldPinIsValid(command.oldPin);
            account.UpdatePin(command.newPin);
            await _bankAccountRepository.UpdateAsync(account);
        }
    }
}
