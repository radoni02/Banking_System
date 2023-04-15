using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Commands
{
    public record UpdateBankAccountCardCommand(Guid Userid,Guid AccountId) : ICommand;
    
    
}
