using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal sealed class User : Entity
    {
        public User(
            Guid userId,
            string firstName,
            string lastName,
            Gender gender,
            string pesel,
            string login,
            string phoneNumber,
            string adressEmail,
            DateTime createdAt,
            List<BankAccount> accounts) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Pesel = pesel;
            Login = login;
            PhoneNumber = phoneNumber;
            AdressEmail = adressEmail;
            CreatedAt = createdAt;
            Accounts = accounts;
        }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public Gender Gender { get; init; }
        public string Pesel { get; init; }
        public string Login { get;private set; }
        public string PhoneNumber { get;private set; }
        public string AdressEmail { get;private set; }
        public DateTime CreatedAt { get; init; }

        public List<BankAccount> Accounts { get; set; } = new();

    }
}
