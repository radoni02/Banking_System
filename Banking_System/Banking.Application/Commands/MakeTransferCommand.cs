using Banking.Application.Dto;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands
{
    public record MakeTransferCommand(Guid UserId,Guid AccountId, BankTransferDto Transferdata) : ICommand;
    
    
}
