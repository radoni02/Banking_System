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

        public BankAccount CreatePersonalAcconut(Guid ownerId, BankingCard card, DateTime createdAt)
        {                                                                    
              var accountNumber = AccountNumber.Create(_generatorService.AccountNumberGenerator());
            var accountBalance = Money.Create(decimal.Zero,Currency.PLN);
              return new BankAccount(ownerId, accountBalance, AccountType.PersonalAccount, card, createdAt ,accountNumber);
        }
     
    }
}
