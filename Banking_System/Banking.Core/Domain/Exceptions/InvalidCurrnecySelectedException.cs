using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class InvalidCurrnecySelectedException : DomainException
    {
        public InvalidCurrnecySelectedException() : base($"The base currency of the account cannot be removed.")
        {
        }
    }
}
