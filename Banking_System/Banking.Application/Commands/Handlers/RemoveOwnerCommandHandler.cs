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
    public class RemoveOwnerCommandHandler : ICommandHandler<RemoveOwnerCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public RemoveOwnerCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(RemoveOwnerCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.OwnerId);
            if (user is null)
            {
                throw new UserNotFoundException(command.OwnerId);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Id == command.AccountId);
            if (account is null)
            {
                throw new AccountNotFoundException();
            }
            var ownerToRemoveFromAccount = await _userRepository.GetAsync(command.OwnerIdToRemove);
            if(ownerToRemoveFromAccount is null)
            {
                throw new UserNotFoundException(command.OwnerIdToRemove);
            }
            ownerToRemoveFromAccount.RemoveBankAccount(command.AccountId);
            account.RemoveOwnerFromAccount(command.OwnerIdToRemove);
            await _userRepository.UpdateAsync(ownerToRemoveFromAccount);
            await _bankAccountRepository.UpdateAsync(account);
        }
    }
}
