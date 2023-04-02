using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Services
{
    public interface ICurrencyChanger
    {
        decimal ChangeCurrency(Currency chosenTransferCurrency,decimal chosenTransferAmount);
    }
}
