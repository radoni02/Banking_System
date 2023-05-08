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
    public sealed class User : AggregateRoot
    {
        private readonly List<BankAccount> _accounts = new();
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public Gender Gender { get; init; }
        public Pesel Pesel { get; init; } 
        public string Login { get;private set; }
        public PhoneNumber PhoneNumber { get;private set; }
        public EmailAddress EmailAddress { get;private set; }

        public DateTime Birthday { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime ModifiedAt { get; private set; }

        public IEnumerable<BankAccount> Accounts => _accounts;

        internal User(string firstName,
            string lastName,
            Gender gender,
            Pesel pesel,
            string login,
            PhoneNumber phoneNumber,
            EmailAddress emailAddress,
            DateTime birthday,
            DateTime createdAt) : base(Guid.NewGuid())
        {

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Pesel = pesel;
            Login = login;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Birthday = birthday;
            CreatedAt = createdAt;
        }
        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetPhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void SetEmailAddress(EmailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public void UserModifiedAt()
        {
            ModifiedAt = DateTime.UtcNow;
        }

        public void UpdateUser(string firstName,string lastName, PhoneNumber phoneNumber, EmailAddress emailAddress)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhoneNumber(phoneNumber);
            SetEmailAddress(emailAddress);
            UserModifiedAt();
            AddEvent(new UserUpdated(this));
        }

        public void AddBankAccount(BankAccount account)
        {
            if(_accounts.Any(x=>x.Id==account.Id))
            {
                throw new BankAccountWithThisIdAlreadyExistsException(account.Id);
            }
            _accounts.Add(account);
            AddEvent(new BankAccountAdded(this, account));
        }
        public void RemoveBankAccount(Guid acconutId)
        {
            var account = GetBankAccount(acconutId);
            _accounts.Remove(account);
            AddEvent(new BankAccountRemoved(this, account));
        }
        public BankAccount GetBankAccount(Guid acconutId)
        {
            var account = _accounts.FirstOrDefault(x=>x.Id == acconutId);
            if(account is null)
            {
                throw new BankAccountNotFoundException(acconutId);
            }
            return account;
        }

    }
}
