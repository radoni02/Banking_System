using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class TransferStatusNotValidException : DomainException
    {
        public TransferStatusNotValidException() : base("transfer status is not successful.")
        {
        }
    }
}
