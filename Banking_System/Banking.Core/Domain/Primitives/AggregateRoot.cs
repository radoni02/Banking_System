using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Primitives
{
    internal abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
