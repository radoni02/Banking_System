using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Entities
{
    internal class Bank
    {
        public string Name { get;private set; }
        public string Krs { get; private set; }
        public string Nip { get; private set; }

        public List<User> Users { get; private set; } = new();
    }
}
