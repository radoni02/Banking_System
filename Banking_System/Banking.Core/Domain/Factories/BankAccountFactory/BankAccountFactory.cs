using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Services;
using Banking.Core.Domain.Services.Policies;
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
        private readonly IAccountPolicy _policy;
        private readonly List<Money> _balances = new List<Money>();
        private readonly List<Guid> _ownersId = new List<Guid>();

        public BankAccountFactory(IGeneratorService generatorService, IAccountPolicy policy)
        {
            _generatorService = generatorService;
            _policy = policy;
        }

        private BankAccount Create(AccountType type, BankingCard card, DateTime createdAt, AccountNumber accountNumber)
            => new(type, card, createdAt, accountNumber);

        public BankAccount CreatePersonalAcconut(AccountType type ,BankingCard card, DateTime createdAt)
        {
            var accountNumber = AccountNumber.Create(_generatorService.AccountNumberGenerator());
            type = AccountType.PersonalAccount;
            var data = new PolicyData(type, _ownersId, _balances);
            _policy.IsApplicable(data);
            _policy.EnforcePolicy(data);

            var bankAccount = Create(AccountType.PersonalAccount, card, createdAt, accountNumber);
            bankAccount.AddBalanceToAccount(Currency.PLN);
              return bankAccount;
        }
     
    }
}
