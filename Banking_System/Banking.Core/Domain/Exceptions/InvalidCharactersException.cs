using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class InvalidCharactersException : DomainException
    {
        public InvalidCharactersException(string value) : base($"{value} have to contain only numbers.")
        {
        }
    }
}
