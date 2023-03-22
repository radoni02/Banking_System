using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class Money
    {
        private Money(decimal accountBalance, Currency currency)
        {
            AccountBalance = accountBalance;
            Currency = currency;
        }

        public decimal AccountBalance { get; private set; }

        public Currency Currency { get; init; }

        public static Money Create(decimal accountBalance,Currency currency)
        {
            
            if (accountBalance != 0)
            {
                throw new Exception();
            }           
            return new Money(accountBalance,currency);
        }
        public void UpdateBalaceSender(decimal amount)
        {
            AccountBalance -= amount;
        }
        public void UpdateBalaceReceiver(decimal amount)
        {
            AccountBalance += amount;
        }
        public void CheckCurrency(Currency currency)
        {
            if(this.Currency !=Currency)
            {
                throw new Exception();
            }

        }
    }
}
