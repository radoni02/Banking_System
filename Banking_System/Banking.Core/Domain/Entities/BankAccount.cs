using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal class BankAccount
    {
        public Guid BankAccountId { get;private set; }
        public Guid OwnerId { get;private set; }
        public decimal AccountBalance { get;private set; }
        public AccountType Type { get;private set; }
        public BankingCard Card { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime ModifiedAt { get;private set; }
    }
}
