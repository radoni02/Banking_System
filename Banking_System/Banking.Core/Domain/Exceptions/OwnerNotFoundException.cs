using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Exceptions
{
    internal sealed class OwnerNotFoundException : DomainException
    {
        public OwnerNotFoundException(Guid id) : base($"Cannot find owner with this id: {id}")
        {
        }
    }
}
