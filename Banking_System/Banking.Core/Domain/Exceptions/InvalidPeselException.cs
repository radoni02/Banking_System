using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class InvalidPeselException : DomainException
    {
        public InvalidPeselException() : base("Invalid pesel, please check pesel or date of birth.")
        {
        }
    }
}
