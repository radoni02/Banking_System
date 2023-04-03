using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    public sealed class AccountNotFoundException : ProjectException
    {
        internal AccountNotFoundException() : base("Account not found",HttpStatusCode.NotFound)
        {
        }
    }
}
