﻿using Banking.Core.Domain.Consts;
using Banking.Core.Domain.Entities;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Factories.BankAccountFactory
{
    public interface IBankAccountFactory
    {
        BankAccount CreateAccount(AccountType type,BankCard card, DateTime createdAt, Guid ownerId,string pin);
    }
}
