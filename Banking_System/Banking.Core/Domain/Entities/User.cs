using Banking.Core.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal class User
    {
        public Guid UserId { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public Gender Gender { get; init; }
        public string Pesel { get;  }
        public string Login { get;private set; }
        public string PhoneNumber { get;private set; }
        public string AdressEmail { get;private set; }
        public DateTime CreatedAt {get; }

        public List<BankAccount> Accounts { get; set; } = new();

    }
}
