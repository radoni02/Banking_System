using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Models
{
    internal class BankingCardReadModel
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public BankCard Type { get; set; }

        public DateTime CardValidityDate { get; set; }

        public string CVV { get; set; }
    }
}
