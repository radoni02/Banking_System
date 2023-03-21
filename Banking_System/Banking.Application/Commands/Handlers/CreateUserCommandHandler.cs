using Banking.Core.Domain.Factories.UserFactory;
using Banking.Core.Domain.Repositories;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserFactory userFactory, IUserRepository userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var (UserId,FirstName, LastName, Gender, Pesel, PhoneNumber, EmailAddress) = command;
            if(await _userRepository.ExistByIdAsync(UserId))
            {
                throw new Exception();
            }
            var user = _userFactory.Create(FirstName, LastName, Gender, Pesel, PhoneNumber, EmailAddress);
            await _userRepository.AddAsync(user);
        }
    }
}
