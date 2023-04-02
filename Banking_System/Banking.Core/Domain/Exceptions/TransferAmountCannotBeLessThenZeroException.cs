using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class TransferAmountCannotBeLessThenZeroException : DomainException
    {
        public TransferAmountCannotBeLessThenZeroException() : base($"Tranfer amount cannot be zero or less then zero.")
        {
        }
    }
}
