using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Services.Policies.Type
{
    public class PersonalAccountPolicy : IAccountPolicy
    {
        public bool IsApplicable(PolicyData data)
        => data.type is Consts.AccountType.PersonalAccount;
        public void EnforcePolicy(PolicyData data)
        {
            if(data.OwnersId.Count!=1)
            {
                throw new Exception();
            }
            if(data.Balances.Count!=1)
            {
                throw new Exception();
            }
        }

       
    }
}
