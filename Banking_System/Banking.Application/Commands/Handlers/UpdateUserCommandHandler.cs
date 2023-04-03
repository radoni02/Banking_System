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
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var (UserId, FirstName, LastName, PhoneNumber, EmailAddress) = command;
            var user = await _userRepository.GetAsync(UserId);
            if(user is null)
            {
                throw new UserNotFoundException();
            }
            user.UpdateUser(FirstName,LastName,PhoneNumber,EmailAddress);
            await _userRepository.UpdateAsync(user);
        }
    }
}
