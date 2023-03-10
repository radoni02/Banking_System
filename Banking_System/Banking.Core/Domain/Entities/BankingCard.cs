using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal sealed class BankingCard : Entity
    {
       
        public BankingCard(Guid accountId,
            string accountNumber,
            DateTime cardValidityDate) : base(accountId)
        {
            AccountNumber = accountNumber;
            CardValidityDate = cardValidityDate;
        }
        public string AccountNumber { get;private set; }

        public DateTime CardValidityDate { get;private set; }
    }
}
