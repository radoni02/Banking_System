using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Services.Policies
{
    public interface IAccountPolicy
    {
        bool IsApplicable(PolicyData data);
        void EnforcePolicy(PolicyData data);
    }
}
