using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Models
{
    internal class BankAccountReadModel
    {
        public Guid Id { get; set; }
        public AccountType Type { get; set; }
        public BankingCardReadModel Card { get; set; }
        public DateTime CreatedAt { get; init; }
        public DateTime ModifiedAt { get; set; }
        public string Pin { get; set; }
        public string AccountNumber { get; set; }
        public ICollection<BankTransferReadModel> Transfers { get; set; }
        public ICollection<Guid> OwnersIds { get; set; }
        public ICollection<MoneyReadModel> Balances { get; set; }
    }
}
