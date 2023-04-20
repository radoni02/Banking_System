using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Models
{
    internal class MoneyReadModel
    {
        public decimal AccountBalance { get; set; }

        public Currency Currency { get; set; }
    }
}
