using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class InvalidEmailProvidedException : DomainException
    {
        public InvalidEmailProvidedException() : base("Email address have to contain @ character.")
        {
        }
    }
}
