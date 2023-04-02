using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class CurrencyAlreadyExistsException : DomainException
    {
        public CurrencyAlreadyExistsException(Currency currency) : base($"Currency {currency} already exists on your account.")
        {
        }
    }
}
