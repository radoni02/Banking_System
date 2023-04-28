using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Models
{
    internal class BankTransferReadModel
    {
        public Guid SenderId { get; set; }
        public Guid ReciverId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsConstant { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string ReceiverAdressAndData { get; set; }
        public string AccountNumber { get; set; }
        public Currency Currency { get; set; }
        public TransferStatus Status { get; set; }
    }
}
