using Banking.Core.Domain.Consts;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities.AccountsEntities
{
    public class PersonalAccount : BankAccount
    {
        public Guid OwnerId { get;private set; }
        public Money AccountBalance { get; private set; }

        public PersonalAccount(Guid bankAccountId, Money accountBalance, Guid ownerId ,AccountType type, BankingCard card, DateTime createdAt, DateTime modifiedAt) : base(bankAccountId, type, card, createdAt, modifiedAt)
        {
            OwnerId = ownerId;
            AccountBalance = accountBalance;
        }
        public void SetOwner(Guid ownerId)
        {
            OwnerId=ownerId;
        }
        //make Banking Card Credit and Debet and add paramiter here to determine 
        public void CheckIfSenderHaveEnoughMoney(decimal amount)
        {
            //should be made on Result.Success etc.
            if(AccountBalance.AccountBalance-amount<0)
            {
                throw new Exception();
            }

        }
    }
}
