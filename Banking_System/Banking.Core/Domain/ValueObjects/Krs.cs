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
    public class Krs : ValueObject
    {

        public const int ValidLength = 10;

        public Krs(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Krs Create(string krs)
        {
            if (string.IsNullOrWhiteSpace(krs))
            {
                throw new EmptyValueException(krs);
            }
            if (krs.Length != ValidLength)
            {
                throw new InvalidLengthException(krs);
            }
            if (!Regex.Match(krs, @"^\d+$").Success)
            {
                throw new InvalidCharactersException(krs); //checks if the krs has only digits
            }
            return new Krs(krs);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
