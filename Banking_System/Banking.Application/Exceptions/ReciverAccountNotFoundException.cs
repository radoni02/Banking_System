using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    internal sealed class ReciverAccountNotFoundException : ProjectException
    {
        internal ReciverAccountNotFoundException() : base("Reciver account not found.",HttpStatusCode.NotFound)
        {
        }
    }
}
