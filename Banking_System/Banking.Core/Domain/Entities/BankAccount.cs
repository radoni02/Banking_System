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

        private readonly List<Guid> _ownersId = new();
        private readonly List<Money> _accountBalances = new();
        internal BankAccount(  Guid bankAccountId,
            AccountType type,
            BankingCard card,
            DateTime createdAt,
            DateTime modifiedAt,
            AccountNumber accountNumber) : base(bankAccountId)
        {
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
            AccountNumber = accountNumber;
        }
        internal BankAccount( 
            AccountType type,
            BankingCard card,
            DateTime createdAt,
            AccountNumber accountNumber) : base(Guid.NewGuid())
        {
            Type = type;
            Card = card;
            CreatedAt = createdAt;
            AccountNumber = accountNumber;
        }

        public AccountType Type { get;private set; }
        public BankingCard Card { get;private set; }
        public DateTime CreatedAt { get; init; }
        public DateTime ModifiedAt { get;private set; }
        public Pin Pin { get;private set; }
        public AccountNumber AccountNumber { get; private set; }
        public IEnumerable<BankTransfer> Transfers => _transfers;
        public IEnumerable<Guid> OwnersId => _ownersId;
        public IEnumerable<Money> AccountBalances => _accountBalances;

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

        public void AddTransfer(BankTransfer banktransfer)
        {
            if(banktransfer.Status!=TransferStatus.Successful)
            {
                throw new TransferStatusNotValidException();

            }
            _transfers.Add(banktransfer);
            AddEvent(new BankTransferAdded(this, banktransfer));
        }
        public TransferStatus CurrencyChecking(Currency currency,TransferStatus status,decimal amount)
        {
            var balance = _accountBalances.FirstOrDefault(x => x.Currency == currency);
            if(balance is null)
            {
                return status;
            }
            UpdateMoneyBalanceReciver(balance,amount);
            status = TransferStatus.Successful;
            AddEvent(new CurrencyChecked(this, currency));
            return status;
        }

        public TransferStatus CheckIfSenderHaveEnoughMoney(decimal amount,BankCard bankCardType,TransferStatus status,Money money)
        {
            //should be made on Result.Success etc.
            if (money.AccountBalance - amount < 0 && bankCardType == BankCard.DebitCard)
            {
                status = TransferStatus.Failed;
               //throw new Exception(); //here insted of throwing exception maybe status.Faild;
            }
            if (money.AccountBalance - amount < -500 && bankCardType == BankCard.CreditCard) //assuming that on credit card is possible to be only -500 
            {
                status = TransferStatus.Failed;
                //throw new Exception();
            }
            return status;

        }

        public void UpdateBankAcconut(Guid ownerId,AccountType type,BankingCard card,AccountNumber accountNumber)
        {
            SetType(type);
            SetCard(card);
            SetAccountNumber(accountNumber);
            AccountModifiedAt();
            AddEvent(new BankAccountUpdated(ownerId, type, card, accountNumber));


        }
        public void UpdateMoneyBalanceSender(Money money,decimal amount)
        {
            money.CheckCurrency(money.Currency);
            money.UpdateBalaceSender(amount);
            AddEvent(new SenderBalanceUpdated(this, money));
        }
        public void UpdateMoneyBalanceReciver(Money money,decimal amount)
        {
            money.CheckCurrency(money.Currency);
            money.UpdateBalaceReceiver(amount);
            AddEvent(new ReciverBalanceUpdated(this, money));
        }

        public void AddOwnerToAccount(Guid ownerid, AccountType type)
        {
            //var owner = CheckIfOwnerExists(ownerid);
            if (_ownersId.Count is 1 && type is not AccountType.CompanyAccount)
            {
                throw new TooManyOwnersException(1);
            }
            if (_ownersId.Count >= 5 && type is AccountType.CompanyAccount)
            {
                throw new TooManyOwnersException(5);
            }
            _ownersId.Add(ownerid);
            AddEvent(new OwnerAdded(this, ownerid));

        }
        public void RemoveOwnerFromAccount(Guid ownerid)
        {
            var owner = CheckIfOwnerExists(ownerid);
            _ownersId.Remove(owner);
            AddEvent(new OwnerRemoved(this, ownerid));
        }
        public List<Guid> GetOwnersOfAccount()
        {
            return this._ownersId;
        }
        private Guid CheckIfOwnerExists(Guid ownerid)
        {
            if (!_ownersId.Contains(ownerid))
            {
                throw new OwnerNotFoundException(ownerid);
            }
            return ownerid;
        }

        public void AddBalanceToAccount(Currency currency, AccountType type)
        {
            if(_accountBalances.Count is 1 && type is not AccountType.ForeignExchangeAccount)
            {
                throw new MoreThenOneBalanceAddedException();
            }
            if(_accountBalances.Count >= Enum.GetValues(typeof(Currency)).Length && type is AccountType.ForeignExchangeAccount)
            {
                throw new MoreBalancesThenAvailableCurrenciesException();
            }
            var balance = CheckIfBalanceExists(currency);
            _accountBalances.Add(balance);
            AddEvent(new BalanceAdded(this, balance));

        }
        public void RemoveBalanceFromAccount(Currency currency)
        {
            if(currency is Currency.PLN)
            {
                throw new InvalidCurrnecySelectedException();
            }
            var balance = _accountBalances.FirstOrDefault(x => x.Currency == currency);
            if(balance is null)
            {
                throw new CurrencyNotFoundException(currency);
            }
            //var balance = CheckIfBalanceExists(currency);
            _accountBalances.Remove(balance);
            AddEvent(new BalanceRemoved(this, balance));
        }

        private Money CheckIfBalanceExists(Currency currency)
        {
            var currencyCheck = _accountBalances.FirstOrDefault(x => x.Currency == currency);
            if (currencyCheck is not null)
            {
                throw new CurrencyAlreadyExistsException(currency);
            }
            var balance = Money.Create(decimal.Zero, currency);
            return balance;
        }

    }
}
