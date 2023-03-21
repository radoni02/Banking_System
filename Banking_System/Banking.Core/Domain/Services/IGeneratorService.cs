using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Services
{
    public interface IGeneratorService
    {
        AccountNumber AccountNumberGenerator();
    }
}
