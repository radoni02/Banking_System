using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public sealed class EmailAddress : ValueObject
    {
        public EmailAddress(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static EmailAddress Create(string emailAddress)
        { 
            if(string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new Exception();
            }
            if(!emailAddress.Contains('@'))
            {
                throw new Exception();
            }
            return new EmailAddress(emailAddress);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
