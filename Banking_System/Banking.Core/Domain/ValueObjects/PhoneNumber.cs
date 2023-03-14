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

        public PhoneNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static PhoneNumber Create(string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new Exception();
            }
            if(phoneNumber.Length != ValidLength)
            {
                throw new Exception();
            }
            if(!Regex.Match(phoneNumber, @"^\d+$").Success)
            {
                throw new Exception(); //checks if the phone number has only digits
            }
            return new PhoneNumber(phoneNumber);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
