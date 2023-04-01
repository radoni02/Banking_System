﻿using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class BankTransfer
    {
        private BankTransfer( bool isConstant, string title, decimal amount, string receiverAdressAndData, AccountNumber accountNumber, Currency currency)
        {
            CreatedAt = DateTime.UtcNow;
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

        public static BankTransfer Create(string title, decimal amount, string receiverAdressAndData, TransferStatus status, bool isConstant, AccountNumber accountNumber,Currency currency)
        { 

            //zastanowic sie jak zrobic ta metode static zeby moc uwtorzyc obiekt trasfer w handlerku
           if(string.IsNullOrWhiteSpace(title)||string.IsNullOrWhiteSpace(receiverAdressAndData))
           {
                status = TransferStatus.Failed;
                throw new Exception();
           }
           if(amount <= decimal.Zero)
           {
                status = TransferStatus.Failed;
                throw new Exception();
           }
           return new BankTransfer( isConstant, title,amount,receiverAdressAndData, accountNumber, currency);
        }
        public BankTransfer ModifyStatus(TransferStatus status)
        {
            return new BankTransfer(IsConstant, Title, Amount, ReceiverAdressAndData, AccountNumber, Currency)
            {
                Status = status
            };
        }
        public decimal GetProperAmountForSender(decimal amount)
        {
            return -amount;
        }
    }
}
