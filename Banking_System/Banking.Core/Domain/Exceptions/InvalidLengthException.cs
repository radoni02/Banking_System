using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class InvalidLengthException : DomainException
    {
        public InvalidLengthException(string value) : base($"Invalid length of {value}.")
        {
        }
    }
}
