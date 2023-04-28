using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class BankTransfer
    {
        private BankTransfer( bool isConstant, string title, decimal amount, string receiverAdressAndData, AccountNumber accountNumber, Currency currency, Guid senderId, Guid reciverId)
        {
            CreatedAt = DateTime.UtcNow;
            IsConstant = isConstant;
            Title = title;
            Amount = amount;
            ReceiverAdressAndData = receiverAdressAndData;
            AccountNumber = accountNumber;
            Currency = currency;
            Status = TransferStatus.Pending;
            SenderId = senderId;
            ReciverId = reciverId;
        }
        public Guid SenderId { get; init; }
        public Guid ReciverId { get; init; }
        public DateTime CreatedAt { get;init; } = DateTime.UtcNow;
        public bool IsConstant { get;init; }
        public string Title { get; init; }
        public decimal Amount { get; init; }
        public string ReceiverAdressAndData { get; init; }
        public AccountNumber AccountNumber { get; init; }
        public Currency Currency { get;init; }
        public TransferStatus Status { get;private set; }

        public static BankTransfer Create(string title, decimal amount,
                                                        string receiverAdressAndData,
                                                        TransferStatus status,
                                                        bool isConstant,
                                                        AccountNumber accountNumber,
                                                        Currency currency,
                                                        Guid senderId,Guid reciverId)
        { 

            //zastanowic sie jak zrobic ta metode static zeby moc uwtorzyc obiekt trasfer w handlerku
           if(string.IsNullOrWhiteSpace(title))
           {
                status = TransferStatus.Failed;
                throw new EmptyValueException(title);
           }
           if(string.IsNullOrWhiteSpace(receiverAdressAndData))
           {
                status = TransferStatus.Failed;
                throw new EmptyValueException(receiverAdressAndData);
           }
           if(amount <= decimal.Zero)
           {
                status = TransferStatus.Failed;
                throw new TransferAmountCannotBeLessThenZeroException();
           }
           return new BankTransfer( isConstant, title,amount,receiverAdressAndData, accountNumber, currency,senderId,reciverId);
        }
        public BankTransfer ModifyStatus(TransferStatus status)
        {
            return new BankTransfer(IsConstant, Title, Amount, ReceiverAdressAndData, AccountNumber, Currency,SenderId,ReciverId)
            {
                Status = status
            };
        }
        public BankTransfer GetTransferForSender(BankTransfer transfer)
        {
            return new BankTransfer(transfer.IsConstant,
                transfer.Title,
                -transfer.Amount,
                transfer.ReceiverAdressAndData,
                transfer.AccountNumber,
                transfer.Currency,
                transfer.SenderId,
                transfer.ReciverId);
        }

    }
}
