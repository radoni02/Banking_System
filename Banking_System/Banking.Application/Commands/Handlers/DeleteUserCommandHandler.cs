using Banking.Core.Domain.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, IBankAccountRepository bankAccountRepository)
        {
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user =await _userRepository.GetAsync(command.UserId);
            ArgumentNullException.ThrowIfNull(user);
            foreach(var account in user.Accounts)
            {
                await _bankAccountRepository.DeleteAsync(account);
            }
            await _userRepository.DeleteAsync(user);
        }
    }
}
