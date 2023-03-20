using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Primitives;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Events
{
    public sealed record BankAccountUpdated(Guid ownerId, AccountType type, BankingCard card, AccountNumber accountNumber) : IDomainEvent
    {
    }
}
