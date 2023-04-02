using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class TooManyOwnersException : DomainException
    {
        public TooManyOwnersException(int max) : base($"Maximum number of owners for this type of account is: {max}.")
        {
        }
    }
}
