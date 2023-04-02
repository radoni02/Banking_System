using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class UnableToCreateBankingCardException : DomainException
    {
        public UnableToCreateBankingCardException() : base($"Unable to create banking card.")
        {
        }
    }
}
