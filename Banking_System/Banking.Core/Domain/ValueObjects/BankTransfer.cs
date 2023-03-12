using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.ValueObjects
{
    public class BankTransfer
    {
        public Guid TransferId { get; init; }
        public DateTime CreatedAt { get;init; }
        public bool IsConstant { get;init; }
        public string Title { get; init; }
        public decimal Amount { get; set; }
        public string ReceiverAdressAndData { get; init; }
        public string AccountNumber { get; init; }

    }
}
