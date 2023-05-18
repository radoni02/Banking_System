using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.ValueObjects;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Factories.UserFactory
{
    internal sealed class UserFactory : IUserFactory
    {
        public User Create(string FirstName, string LastName, Gender gender, string pesel, string phoneNumber, string emailAddress, DateTime birthday)
        {
            var LoginPart1 = FirstName.Substring(0, 3);
            var LoginPart2 = LastName.Substring(0, 3);
            //there will be external service to generate random number
            var login = LoginPart1 + LoginPart2;
            var phoneNumberObject = PhoneNumber.Create(phoneNumber);
            var peselObject = Pesel.Create(pesel, birthday);
            var emailAddressObject = EmailAddress.Create(emailAddress);
            var user = new User(FirstName, LastName, gender, peselObject, login, phoneNumberObject, emailAddressObject, DateTime.UtcNow,birthday);
            return user;
        }

    }
}
