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
    public sealed class PhoneNumber : ValueObject
    {
        public const int ValidLength = 9;

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static PhoneNumber Create(string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new EmptyValueException(phoneNumber);
            }
            if(phoneNumber.Length != ValidLength)
            {
                throw new InvalidLengthException(phoneNumber);
            }
            if(!Regex.Match(phoneNumber, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(phoneNumber); //checks if the phone number has only digits
            }
            return new PhoneNumber(phoneNumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
