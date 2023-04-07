﻿using Banking.Core.Domain.Consts;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands
{
    public record AddBalance(Guid OwnerId,AccountType Type,Currency Currency) : ICommand;
    
    
}
