using Banking.Core.Domain.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class DeleteBankAccountHandler : ICommandHandler<DeleteBankAccount>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public DeleteBankAccountHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(DeleteBankAccount command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.OwnerId);
            ArgumentNullException.ThrowIfNull(user);
            user.RemoveBankAccount(command.AccountId);
            var bankAccount = await _bankAccountRepository.GetAsync(command.AccountId);
            ArgumentNullException.ThrowIfNull(bankAccount);
            if(bankAccount.Type is not Core.Domain.Consts.AccountType.CompanyAccount)
            {
                await _bankAccountRepository.DeleteAsync(bankAccount);
            }
            else
            {
                bankAccount.RemoveOwnerFromAccount(command.AccountId);
                await _bankAccountRepository.UpdateAsync(bankAccount);
            }
            await _userRepository.UpdateAsync(user);
            //edit//this method should work only if user have more then 1 bankAccount, we dont allow user to have 0 bankAccount

        }
    }
}
