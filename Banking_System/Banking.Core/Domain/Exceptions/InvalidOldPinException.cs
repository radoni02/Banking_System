using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    public class InvalidOldPinException : DomainException
    {
        public InvalidOldPinException() : base($"Invalid old pin.")
        {
        }
    }
}
