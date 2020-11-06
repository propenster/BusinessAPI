using BusinessAPI.Domain.Bank;
using BusinessAPI.Services;
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
    public class BanksController : ControllerBase
    {

        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [Route("GetAllBanksAndBankCodes")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBanksAndBankCodes()
        {
            var banks = await _bankService.GetAllBanksAndCodes();
            return Ok(banks);
        }

        [Route("GetBankById")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBankById(int Id)
        {
            var bank = await _bankService.GetBankById(Id);
            return Ok(bank);
        }

        [Route("GetBankByCBNCode")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBankByCBNCode(string BankCBNCode)
        {
            var bank = await _bankService.GetBankByCBNCode(BankCBNCode);
            return Ok(bank);
        }

        [Route("GetBankByShortCode")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBankByShortCode(string BankShortCode)
        {
            var bank = await _bankService.GetBankByShortCode(BankShortCode);
            return Ok(bank);
        }

        [Route("AddBank")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBank([FromBody] Bank bank)
        {
            var result = await _bankService.AddBank(bank);
            return Ok(result);
        }

        [Route("UpdateBank")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBank([FromBody] Bank bank)
        {
            var result = await _bankService.UpdateBank(bank);
            return Ok(result);
        }

        [Route("DeleteBank")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBank(int Id)
        {
            await _bankService.DeleteBank(Id);
            return Ok();
        }

    }
}
