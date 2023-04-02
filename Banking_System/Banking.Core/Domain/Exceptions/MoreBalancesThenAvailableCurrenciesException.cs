using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class MoreBalancesThenAvailableCurrenciesException : DomainException
    {
        public MoreBalancesThenAvailableCurrenciesException() : base($"Not possible to create more balances then available currencies.")
        {
        }
    }
}
