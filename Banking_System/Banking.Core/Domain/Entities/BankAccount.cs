using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Primitives;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal sealed class BankAccount : Entity 
    {
        public BankAccount(Guid bankAccountId,
            Guid ownerId,
            decimal accountBalance,
            AccountType type,
            BankingCard card,
            DateTime createdAt,
            DateTime modifiedAt) : base(bankAccountId)
        {
            OwnerId = ownerId;
            AccountBalance = accountBalance;
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
        public Guid OwnerId { get;private set; }
        public decimal AccountBalance { get;private set; }
        public AccountType Type { get;private set; }
        public BankingCard Card { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime ModifiedAt { get;private set; }
        public List<BankTransfer> Transfers { get; private set; } = new();
    }
}
