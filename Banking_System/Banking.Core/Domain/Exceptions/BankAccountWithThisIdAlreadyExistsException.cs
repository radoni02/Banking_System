using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class BankAccountWithThisIdAlreadyExistsException : DomainException
    {
        public BankAccountWithThisIdAlreadyExistsException(Guid id) : base($"Bank account with id:{id} already exists.")
        {
        }
    }
}
