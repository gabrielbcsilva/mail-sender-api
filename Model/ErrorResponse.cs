using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mailSender_api.Model
{
    public class ErrorResponse
    {
     
         
        public ErrorResponse()
        {
            traceId = Guid.NewGuid().ToString();
            message = "";
        }

        public ErrorResponse(string StatusCode, string Message)
        {
            traceId = Guid.NewGuid().ToString();
            statusCode = StatusCode;
            message = Message;
        }

        public string traceId { get; private set; }
        public string statusCode { get; private set; }
        public string message { get; private set; }

    }
}