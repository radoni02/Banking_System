using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    internal sealed class SenderBalanceNotFoundException : ProjectException
    {
        internal SenderBalanceNotFoundException(Currency currency) : base($"Balance with currency {currency} not found.",HttpStatusCode.NotFound)
        {
        }
    }
}
