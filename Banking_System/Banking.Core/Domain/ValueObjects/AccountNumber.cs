using Banking.Core.Domain.Exceptions;
using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class AccountNumber : ValueObject
    {
        public const int ValidLength = 26;
        private AccountNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static AccountNumber Create(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new EmptyValueException(accountNumber);
            }
            if (accountNumber.Length != ValidLength)
            {
                throw new InvalidLengthException(accountNumber);
            }
            if (!Regex.Match(accountNumber, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(accountNumber);
            }
            return new AccountNumber(accountNumber);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static implicit operator string(AccountNumber number)
            =>number.Value;
        public static implicit operator AccountNumber(string number)
           => new(number);
    }
}
