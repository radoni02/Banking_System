using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Exceptions
{
    public class ProjectException : Exception
    {
        protected ProjectException(string message, HttpStatusCode errorCode=HttpStatusCode.BadRequest) : base(message)
        {
            ErrorCode = errorCode;
        }

        public HttpStatusCode ErrorCode { get; }
    }
}
