using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    public class BankingCard
    {
        public Guid AccountId { get;private set; }
        public string AccountNumber { get;private set; }

        public DateTime CardValidityDate { get;private set; }
    }
}
