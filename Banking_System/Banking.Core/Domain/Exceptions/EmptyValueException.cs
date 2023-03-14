using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class EmptyValueException : DomainException
    {
        public EmptyValueException(string value) : base($"{value} cannot be null.")
        {
        }
    }
}
