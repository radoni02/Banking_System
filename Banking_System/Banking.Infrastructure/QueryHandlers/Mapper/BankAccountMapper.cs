using Banking.Application.Dto;
using Banking.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.QueryHandlers.Mapper
{
    internal static class BankAccountMapper
    {
        public static BankAccountDto AsDto(this BankAccountReadModel readModel)
            => new()
            {
                Type = readModel.Type,
                Card = new BankingCardDto
                {
                    CardNumber=readModel.Card.CardNumber,
                    CardHolderName=readModel.Card.CardHolderName,
                    Type = readModel.Card.Type,
                    CardValidityDate=readModel.Card.CardValidityDate,
                    CVV=readModel.Card.CVV
                },
                CreatedAt = readModel.CreatedAt,
                ModifiedAt = readModel.ModifiedAt,
                Pin=readModel.Pin,
                AccountNumber=readModel.AccountNumber,
                Transfers = readModel.Transfers?.Select(t=> new BankTransferDto
                {
                    IsConstant = t.IsConstant,
                    Title=t.Title,
                    Amount=t.Amount,
                    ReceiverAdressAndData=t.ReceiverAdressAndData,
                    AccountNumber=t.AccountNumber,
                    Currency=t.Currency
                })
                
            };
    }
}
