using Banking.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal class Bank
    {
        public Guid Bank_Id { get;private set; }
        public string Name { get;private set; }
        public Krs Krs { get; private set; }
        public Nip Nip { get; private set; }

        public List<User> Users { get; private set; } = new();
    }
}
