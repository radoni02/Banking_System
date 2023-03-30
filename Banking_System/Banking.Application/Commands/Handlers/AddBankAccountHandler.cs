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
    public class AddBankAccountHandler : ICommandHandler<AddBankAccount>
    {
        private readonly IBankAccountFactory _bankAccountFactory;
        private readonly IUserRepository _userRepository;

        public AddBankAccountHandler(IBankAccountFactory bankAccountFactory, IUserRepository userRepository)
        {
            _bankAccountFactory = bankAccountFactory;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(AddBankAccount command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _userRepository.GetAsync(command.ownerId);
            ArgumentNullException.ThrowIfNull(user);
            var account =  _bankAccountFactory.CreateAccount(command.type,command.card,DateTime.UtcNow,command.ownerId);
            ArgumentNullException.ThrowIfNull(account);
            user.AddBankAccount(account);
            await _userRepository.UpdateAsync(user);
            //should I also update BankAccountRepository here?
        }
    }
}
