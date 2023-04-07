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
    public class AddOwnerHandler : ICommandHandler<AddOwner>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        public AddOwnerHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(AddOwner command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.OwnerId);
            if(user is null)
            {
                throw new UserNotFoundException(command.OwnerId);
            }
            var newOwner = await _userRepository.GetAsync(command.newOwnerId);
            if(newOwner is null)
            {
                throw new UserNotFoundException(command.newOwnerId);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Id == command.BankAccountId);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            newOwner.AddBankAccount(account);
            account.AddOwnerToAccount(command.newOwnerId, account.Type);
            await _userRepository.UpdateAsync(user);
            await _bankAccountRepository.UpdateAsync(account);

        }
    }
}
