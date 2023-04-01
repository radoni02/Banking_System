using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Services;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Factories.BankAccountFactory
{
    public sealed class BankAccountFactory : IBankAccountFactory
    {
        private readonly IGeneratorService _generatorService;

        public BankAccountFactory(IGeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        private BankAccount Create(AccountType type, BankingCard card, DateTime createdAt, AccountNumber accountNumber)
            => new(type, card, createdAt, accountNumber);

        public BankAccount CreateAccount(AccountType accountType ,BankCard card, DateTime createdAt,Guid ownerId)
        {
            var accountNumber = AccountNumber.Create(_generatorService.AccountNumberGenerator());
            var bankingCard = _generatorService.BankingCardGenerator(card);
            var cardType = card is BankCard.CreditCard ?
                BankingCard.CreateCreditCard(bankingCard.CardNumber,bankingCard.CardHolderName,card,bankingCard.CardValidityDate,bankingCard.CVV)
                : BankingCard.CreateDebitCard(bankingCard.CardNumber, bankingCard.CardHolderName, card, bankingCard.CardValidityDate, bankingCard.CVV);
            var bankAccount = Create(accountType, cardType, createdAt, accountNumber);
            bankAccount.AddOwnerToAccount(ownerId,accountType);
            bankAccount.AddBalanceToAccount(Currency.PLN,accountType);
            return bankAccount;
        }
     
    }
}
