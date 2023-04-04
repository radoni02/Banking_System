using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Events
{
    public sealed record CurrencyChecked(BankAccount bankAccount,Currency currency): IDomainEvent
    {
    }
}
