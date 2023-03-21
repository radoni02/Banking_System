using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Events;
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
            AccountNumber accountNumber) : base(Guid.NewGuid())
        {
            OwnerId = ownerId;
            AccountBalance = accountBalance;
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            AccountNumber = accountNumber;
        }

        public Guid OwnerId { get; private set; }
        public Money AccountBalance { get; private set; }
        public AccountType Type { get;private set; }
        public BankingCard Card { get;private set; }
        public DateTime CreatedAt { get; init; }
        public DateTime ModifiedAt { get;private set; }
        public Pin Pin { get;private set; }
        public AccountNumber AccountNumber { get; private set; }
        public IEnumerable<BankTransfer> Transfers => _transfers;

        public void SetPin(Pin pin)
        {
            Pin = pin;
        }

        public void SetCard(BankingCard card)
        {
            Card = card;
        }

        public void SetType(AccountType type)
        {
            Type = type;
        }

        public void AccountModifiedAt()
        {
            ModifiedAt = DateTime.UtcNow;
        }

        public void SetAccountNumber(AccountNumber accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void SetOwner(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        public void AddTransfer(BankTransfer banktransfer)
        {
            if(banktransfer.Status!=TransferStatus.Successful)
            {
                throw new Exception(); //should I throw exception here? maybe unitOFWork pattern

            }
            _transfers.Add(banktransfer);
            AddEvent(new BankTransferAdded(this, banktransfer));
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
        public void UpdateBankAcconut(Guid ownerId,AccountType type,BankingCard card,AccountNumber accountNumber)
        {
            SetOwner(ownerId);
            SetType(type);
            SetCard(card);
            SetAccountNumber(accountNumber);
            AccountModifiedAt();
            AddEvent(new BankAccountUpdated(ownerId, type, card, accountNumber));


        }
        public void UpdateMoneyBalanceSender(Money money)
        {
            if(AccountBalance.Currency != money.Currency)
            {
                throw new Exception();
            }
            AccountBalance.UpdateBalaceSender(money.AccountBalance);
        }
        public void UpdateMoneyBalanceReciver(Money money)
        {
            if (AccountBalance.Currency != money.Currency)
            {
                throw new Exception();
            }
            AccountBalance.UpdateBalaceReceiver(money.AccountBalance);
        }

    }
}
