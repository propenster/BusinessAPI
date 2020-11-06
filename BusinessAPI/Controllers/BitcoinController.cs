using BusinessAPI.Domain.Bitcoin;
using BusinessAPI.Services.Bitcoin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BitcoinController : ControllerBase
    {
        private readonly IBitcoinService _bitcoinService;

        public BitcoinController(IBitcoinService bitcoinService)
        {
            _bitcoinService = bitcoinService;
        }

       ////
       [Route("GetAllBitcoinTickers")]
       [HttpGet]
       [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<IActionResult> GetAllBitcoinTickers()
        {
            var result = await _bitcoinService.GetAllBitcoinTickers();
            return Ok(result);
        }

        [Route("GetBitcoinBalance")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBitcoinBalance(string wallet_id)
        {
            var result = await _bitcoinService.GetBitcoinBalance(wallet_id);
            return Ok(result);
        }

        [Route("GetBitcoinTickerForCurrency")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBitcoinTickerForCurrency(BitcoinTickerForCurrencyModel tickerForCurrencyModel)
        {
            var result = await _bitcoinService.GetBitcoinTickerForCurrency(tickerForCurrencyModel);
            return Ok(result);
        }
    }
}
