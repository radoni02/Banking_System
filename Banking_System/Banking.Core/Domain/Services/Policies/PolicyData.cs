using Banking.Core.Domain.Consts;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Services.Policies
{
    public record PolicyData(AccountType type,List<Guid> OwnersId,List<Money> Balances);
    
    
}
