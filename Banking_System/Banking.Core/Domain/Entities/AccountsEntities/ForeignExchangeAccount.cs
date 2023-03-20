using Banking.Core.Domain.Consts;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities.AccountsEntities
{
    public sealed class ForeignExchangeAccount : BankAccount
    {
        internal ForeignExchangeAccount(Guid ownerId, Money accountBalance, Guid bankAccountId, AccountType type, BankingCard card, DateTime createdAt, DateTime modifiedAt, AccountNumber accountNumber)
            : base(ownerId, accountBalance, bankAccountId, type, card, createdAt, modifiedAt, accountNumber) { }

        public List<Guid> OwnersId { get; set; }

        public void AddOwner(Guid owner)
        {
            if(OwnersId.Contains(owner) || owner == OwnerId)
            {
                throw new Exception();
            }
            OwnersId.Add(owner);
        }
        public void RemoveOwner(Guid owner)
        {
            if(!OwnersId.Contains(owner))
            {
                throw new Exception();
            }
            OwnersId.Remove(owner);
        }

    }
}
