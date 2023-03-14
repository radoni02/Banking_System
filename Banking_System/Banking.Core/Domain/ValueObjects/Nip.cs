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
    public class Nip : ValueObject
    {
        public const int ValidLength = 10;

        public Nip(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Nip Create(string nip)
        {
            if (string.IsNullOrWhiteSpace(nip))
            {
                throw new EmptyValueException(nip);
            }
            if (nip.Length != ValidLength)
            {
                throw new InvalidLengthException(nip);
            }
            if (!Regex.Match(nip, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(nip); //checks if the krs has only digits
            }
            return new Nip(nip);
        }

        
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
