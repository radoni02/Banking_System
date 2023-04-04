using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Primitives;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Events
{
    public sealed record SenderBalanceUpdated(BankAccount bankAccount, Money money) : IDomainEvent
    {
    }
}
