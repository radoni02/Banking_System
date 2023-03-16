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
    public sealed class Pin : ValueObject
    {
        public const int ValidLength = 4;

        private Pin(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Pin Create(string pin)
        {
            if (string.IsNullOrWhiteSpace(pin))
            {
                throw new EmptyValueException(pin);
            }
            if (pin.Length != ValidLength)
            {
                throw new InvalidLengthException(pin);
            }
            if (!Regex.Match(pin, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(pin); 
            }
            return new Pin(pin);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
