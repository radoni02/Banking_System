using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class MoreThenOneBalanceAddedException : DomainException
    {
        public MoreThenOneBalanceAddedException() : base($"This type of account cannot have more then one balance.")
        {
        }
    }
}
