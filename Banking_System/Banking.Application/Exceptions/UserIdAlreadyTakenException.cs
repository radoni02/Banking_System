using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    public sealed class UserIdAlreadyTakenException : RpcException
    {
        internal UserIdAlreadyTakenException() : base(new Status(StatusCode.InvalidArgument, "UserId is already taken"))
        {
        }
    }
}
