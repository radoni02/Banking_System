using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class DefaultAccountBalanceIsNotZeroException : DomainException
    {
        public DefaultAccountBalanceIsNotZeroException() : base($"Default account balance have to be zero.")
        {
        }
    }
}
