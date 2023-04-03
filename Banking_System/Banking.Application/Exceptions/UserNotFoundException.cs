using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    public sealed class UserNotFoundException : ProjectException
    {
        internal UserNotFoundException() : base("User not found.",HttpStatusCode.NotFound)
        {
        }
    }
}
