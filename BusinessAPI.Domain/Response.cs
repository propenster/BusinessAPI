using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAPI.Domain
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string RequestId { get; set; }
        public object Data { get; set; }

    }
}
