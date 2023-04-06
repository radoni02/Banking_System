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
        internal UserNotFoundException(Guid id) : base($"User with id:{id} not found.",HttpStatusCode.NotFound)
        {
        }
    }
}
