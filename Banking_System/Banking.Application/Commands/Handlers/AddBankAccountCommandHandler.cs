using Banking.Application.Exceptions;
using Banking.Core.Domain.Factories.BankAccountFactory;
using Banking.Core.Domain.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class AddBankAccountCommandHandler : ICommandHandler<AddBankAccountCommand>
    {
        private readonly IBankAccountFactory _bankAccountFactory;
        private readonly IUserRepository _userRepository;

        public AddBankAccountCommandHandler(IBankAccountFactory bankAccountFactory, IUserRepository userRepository)
        {
            _bankAccountFactory = bankAccountFactory;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(AddBankAccountCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.OwnerId);
            if(user is null)
            {
                throw new UserNotFoundException(command.OwnerId);
            }
            var account =  _bankAccountFactory.CreateAccount(command.Type,command.Card,DateTime.UtcNow,command.OwnerId,command.pin);
            if(account is null)
            {
                throw new AccountNotFoundException();
            }
            user.AddBankAccount(account);
            await _userRepository.UpdateAsync(user);
            //should I also update BankAccountRepository here?
        }
    }
}
