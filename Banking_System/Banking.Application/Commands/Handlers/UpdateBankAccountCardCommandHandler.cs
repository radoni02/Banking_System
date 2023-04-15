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
    public class UpdateBankAccountCardCommandHandler : ICommandHandler<UpdateBankAccountCardCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public UpdateBankAccountCardCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(UpdateBankAccountCardCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.Userid);
            if(user is null)
            {
                throw new UserNotFoundException(command.Userid);
            }
            var account = user.Accounts.FirstOrDefault(x => x.Id == command.AccountId);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            account.ChangeCardtype(account.Card);
            await _bankAccountRepository.UpdateAsync(account);
        }
    }
}
