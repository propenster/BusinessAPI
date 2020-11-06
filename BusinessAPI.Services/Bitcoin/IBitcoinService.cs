using BusinessAPI.Domain;
using BusinessAPI.Domain.Bitcoin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services.Bitcoin
{
    public interface IBitcoinService
    {

        Task<Response> GetAllBitcoinTickers();
        Task<Response> GetBitcoinTickerForCurrency(BitcoinTickerForCurrencyModel tickerForCurrencyModel);
        Task<Response> GetBitcoinBalance(string wallet_id);
    }
}
