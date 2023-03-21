using Banking.Core.Domain.Consts;
using Banking.Core.Domain.ValueObjects;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands
{
    public record CreateUserCommand(Guid UserId,string FirstName, string LastName, Gender Gender, Pesel pesel, PhoneNumber PhoneNumber, EmailAddress EmailAddress) : ICommand
    {
    }
}
