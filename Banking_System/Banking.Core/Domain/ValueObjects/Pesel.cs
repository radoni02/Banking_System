using Banking.Core.Domain.Exceptions;
using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class Pesel : ValueObject
    {
        public const int ValidLength = 11;
        
        public Pesel(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Pesel Create(string pesel,DateTime birthday)
        {
            if(string.IsNullOrWhiteSpace(pesel))
            {
                throw new EmptyValueException(pesel);
            }
            if (pesel.Length!= ValidLength)
            {
                throw new InvalidLengthException(pesel);
            }
           if(birthday.Year.ToString().Substring(2)!=pesel.Substring(0,2) &&
                birthday.Month.ToString() != pesel.Substring(2, 2) &&
                    birthday.Day.ToString() != pesel.Substring(4, 2))
            {
                throw new InvalidPeselException();
            }
            return new Pesel(pesel);     
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
