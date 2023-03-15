using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Events
{
    internal sealed record BankAccountAdded(User user, BankAccount account) : IDomainEvent;
    
    
}
