﻿using Banking.Application.Exceptions;
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
            if(user is null)
            {
                throw new UserNotFoundException(command.UserId);
            }
            foreach(var account in user.Accounts)
            {
                if (account.Type is not Core.Domain.Consts.AccountType.CompanyAccount)
                {
                    await _bankAccountRepository.DeleteAsync(account);
                }
                else
                {
                    account.RemoveOwnerFromAccount(command.UserId);
                }
                
            }
            await _userRepository.DeleteAsync(user);
        }
    }
}
