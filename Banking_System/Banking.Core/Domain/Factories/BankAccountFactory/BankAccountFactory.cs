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

        public BankAccount CreateAccount(AccountType type ,BankingCard card, DateTime createdAt,Guid ownerId)
        {
            var accountNumber = AccountNumber.Create(_generatorService.AccountNumberGenerator());
            var bankAccount = Create(type, card, createdAt, accountNumber);
            bankAccount.AddOwnerToAccount(ownerId,type);
            bankAccount.AddBalanceToAccount(Currency.PLN,type);
            return bankAccount;
        }
     
    }
}
