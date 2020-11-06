using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAPI.Domain.Config
{
    public class BitcoinAPISettings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string XForwardedFor { get; set; }

        public string BearerToken { get; set; }
    }
}
