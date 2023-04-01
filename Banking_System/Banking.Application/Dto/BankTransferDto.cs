using Banking.Core.Domain.Consts;
using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Dto
{
    public class BankTransferDto
    {
        public bool IsConstant { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string ReceiverAdressAndData { get; set; }
        public AccountNumber AccountNumber { get; set; }
        public Currency Currency { get; set; }
    }
}
