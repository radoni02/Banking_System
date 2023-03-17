using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class BankTransfer
    {
        private BankTransfer( DateTime createdAt, bool isConstant, string title, decimal amount, string receiverAdressAndData, AccountNumber accountNumber, Currency currency)
        {
            CreatedAt = createdAt;
            IsConstant = isConstant;
            Title = title;
            Amount = amount;
            ReceiverAdressAndData = receiverAdressAndData;
            AccountNumber = accountNumber;
            Currency = currency;
            Status = TransferStatus.Pending;
        }

        public DateTime CreatedAt { get;init; } = DateTime.UtcNow;
        public bool IsConstant { get;init; }
        public string Title { get; init; }
        public decimal Amount { get; init; }
        public string ReceiverAdressAndData { get; init; }
        public AccountNumber AccountNumber { get; init; }
        public Currency Currency { get;init; }
        public TransferStatus Status { get;private set; }

        public BankTransfer Create(string title, decimal amount, string receiverAdressAndData)
        {
           if(string.IsNullOrWhiteSpace(title)||string.IsNullOrWhiteSpace(receiverAdressAndData))
           {
                Status = TransferStatus.Failed;
                throw new Exception();
           }
           if(amount <= decimal.Zero)
           {
                Status = TransferStatus.Failed;
                throw new Exception();
           }
           return new BankTransfer(CreatedAt, IsConstant, title,amount,receiverAdressAndData, AccountNumber, Currency);
        }
        public BankTransfer ModifyStatus(TransferStatus status)
        {
            return new BankTransfer(CreatedAt, IsConstant, Title, Amount, ReceiverAdressAndData, AccountNumber, Currency)
            {
                Status = status
            };
        }
    }
}
