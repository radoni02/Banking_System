using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    internal sealed class ReciverBalanceNotFoundException : ProjectException
    {
        internal ReciverBalanceNotFoundException() : base("Reciver balance not found.",HttpStatusCode.NotFound)
        {
        }
    }
}
