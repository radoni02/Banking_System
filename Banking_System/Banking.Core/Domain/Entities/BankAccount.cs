using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Exceptions;
using Banking.Core.Domain.Primitives;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    public class BankAccount : AggregateRoot 
    {
        private readonly List<BankTransfer> _transfers = new();
        internal BankAccount(Guid ownerId, Money accountBalance, Guid bankAccountId,
            AccountType type,
            BankingCard card,
            DateTime createdAt,
            DateTime modifiedAt,
            AccountNumber accountNumber) : base(bankAccountId)
        {
            OwnerId = ownerId;
            AccountBalance = accountBalance;
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            AccountNumber = accountNumber;
        }
        internal BankAccount(Guid ownerId, Money accountBalance,
            AccountType type,
            BankingCard card,
            DateTime createdAt,
            DateTime modifiedAt,
            AccountNumber accountNumber) : base(Guid.NewGuid())
        {
            OwnerId = ownerId;
            AccountBalance = accountBalance;
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            AccountNumber = accountNumber;
        }

        public Guid OwnerId { get; private set; }
        public Money AccountBalance { get; private set; }
        public AccountType Type { get;private set; }
        public BankingCard Card { get;private set; }
        public DateTime CreatedAt { get;private set; }
        public DateTime ModifiedAt { get;private set; }
        public Pin Pin { get;private set; }
        public AccountNumber AccountNumber { get; private set; }
        public IEnumerable<BankTransfer> Transfers => _transfers;

        public void SetPin(Pin pin)
        {
            Pin = pin;
        }

        public void AcconutModifiedAt()
        {
            ModifiedAt = DateTime.UtcNow;
        }

        public void AddTransfer(BankTransfer Banktransfer)
        {
            if(Banktransfer.Status!=TransferStatus.Successful)
            {
                throw new Exception(); //should I throw exception here? maybe unitOFWork pattern

            }
            _transfers.Add(Banktransfer);
        }
        public void SetOwner(Guid ownerId)
        {
            OwnerId = ownerId;
        }
        public void CheckIfSenderHaveEnoughMoney(decimal amount,BankCard type,TransferStatus status)
        {
            //should be made on Result.Success etc.
            if (AccountBalance.AccountBalance - amount < 0 && type == BankCard.DebitCard)
            {
                status = TransferStatus.Failed;
               //throw new Exception(); //here insted of throwing exception maybe status.Faild;
            }
            if (AccountBalance.AccountBalance - amount < -500 && type == BankCard.CreditCard) //assuming that on credit card is possible to be only -500 
            {
                status = TransferStatus.Failed;
                //throw new Exception();
            }

        }

    }
}
