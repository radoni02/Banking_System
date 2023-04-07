using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class CurrencyNotFoundException : DomainException
    {
        public CurrencyNotFoundException(Currency currency) : base($"Currency {currency} not found on this account.")
        {
        }
    }
}
