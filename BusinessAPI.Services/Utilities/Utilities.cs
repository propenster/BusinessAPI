using BusinessAPI.Domain;
using BusinessAPI.Services.Airport;
using BusinessAPI.Services.Bitcoin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessAPI.Services
{
    public class Utilities
    {
        private readonly ILogger<Utilities> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<AirportService> logger;
        private ILogger<BitcoinService> logger1;
        private ILogger<BankService> logger2;

        public Utilities(ILogger<Utilities> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public Utilities(ILogger<AirportService> logger)
        {
            this.logger = logger;
        }

        public Utilities(ILogger<BitcoinService> logger1)
        {
            this.logger1 = logger1;
        }

        public Utilities(ILogger<BankService> logger2)
        {
            this.logger2 = logger2;
        }

        public Response InitializeResponse()
        {
            Response response = new Response();
            string requestId = String.Format("{0}_{1:N}", "", Guid.NewGuid());
            response.RequestId = requestId;
            response.ResponseCode = "00";
            response.ResponseMessage = "Successful";
            return response;
        }

        public Response UnsuccessfulResponse(Response response, string message, string data = null)
        {
            response.ResponseCode = "02";
            response.ResponseMessage = message;
            response.Data = data;
            return response;
        }

        public Response CatchException(Response response)
        {
            response.ResponseCode = "99";
            response.ResponseMessage = "Error occurred while processing your request";
            return response;
        }



    }
}
