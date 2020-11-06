using BusinessAPI.Domain;
using BusinessAPI.Domain.Bitcoin;
using BusinessAPI.Domain.Config;
using BusinessAPI.Domain.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services.Bitcoin
{
    public class BitcoinService : IBitcoinService
    {
        private static BitcoinAPISettings _settings;
        private readonly ILogger<BitcoinService> _logger;
        private readonly Utilities _utilities;

        public BitcoinService(IOptions<BitcoinAPISettings> settings, ILogger<BitcoinService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
            _utilities = new Utilities(logger);

        }

        public async Task<Response> GetAllBitcoinTickers()
        {
            Response response = _utilities.InitializeResponse();

            try
            {
                string url = _settings.BaseUrl + $"/ticker";
                var getAllBitcoinTickers = await ApiHelper.DoWebRequestAsync<Response>(url, null, "GET", null);
                if(getAllBitcoinTickers == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseCode = "Could not fetch API";
                }
                response.Data = getAllBitcoinTickers;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch(Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY =>  REQUEST ID => {response.RequestId}");
            }
            return response;
            
        }

        public async Task<Response> GetBitcoinBalance(string wallet_id)
        {
            string url = _settings.BaseUrl + $"/api/Wallet/v1/checkbalance?wallet_id={wallet_id}";
            Dictionary<string, string> header = new Dictionary<string, string>
            {
                { "ApiKey", _settings.ApiKey },
                //{"Authorization", string.Format("Bearer {0}",_settings.BearerToken) },
                //{"XForwardedFor", _settings.XForwardedFor }
            };

            var response = await ApiHelper.DoWebRequestAsync<Response>(url, "", "GET", header);
            return response;
        }

        public async Task<Response> GetBitcoinTickerForCurrency(BitcoinTickerForCurrencyModel tickerForCurrencyModel)
        {
            string url = _settings.BaseUrl + $"/api/gettickerforcurrency";
            var response = await ApiHelper.DoWebRequestAsync<Response>(url, tickerForCurrencyModel, "GET", null, _settings.ApiKey);
            return response;
        }

        
    }
}
