﻿using Banking.Core.Domain.Exceptions;
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
        private EmailAddress(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static EmailAddress Create(string emailAddress)
        { 
            if(string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new EmptyValueException(emailAddress);
            }
            if(!emailAddress.Contains('@'))
            {
                throw new InvalidEmailProvidedException();
            }
            return new EmailAddress(emailAddress);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
