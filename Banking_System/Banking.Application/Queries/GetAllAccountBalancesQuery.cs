using Banking.Application.Dto;
using Convey.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Queries
{
    public record GetAllAccountBalancesQuery(Guid UserId,Guid AccountId) : IQuery<IEnumerable<OwnerDto>>;
    
    
}
