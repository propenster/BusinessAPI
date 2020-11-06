using BusinessAPI.DataAccess;
using BusinessAPI.Domain;
using BusinessAPI.Domain.Bank;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services
{
    public class BankService : IBankService
    {

        private readonly IBankRepository _bankRepository;
        private readonly Utilities _utilities;
        private readonly ILogger<BankService> _logger;

        public BankService(IBankRepository bankRepository, ILogger<BankService> logger)
        {
            _bankRepository = bankRepository;
            _logger = logger;
            _utilities = new Utilities(_logger);
        }

        public async Task<Response> AddBank(Bank bank)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
               int addedBanks = await _bankRepository.AddBank(bank);
                if (addedBanks > 0)
                    response.Data = "Bank added successfully";
                if(addedBanks == 0)
                {
                    return _utilities.UnsuccessfulResponse(response, "Unable to save Bank");
                }
                             
            }catch(Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> DeleteBank(int Id)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                int addedBank = await _bankRepository.DeleteBank(Id);
                if (addedBank > 0)
                    response.Data = "Airport Deleted Successfully";
                if (addedBank < 0)
                    response.Data = "Airport Does not Exist";
                if (addedBank == 0)
                {
                    return _utilities.UnsuccessfulResponse(response, "Unable to Delete Beneficiary");
                }
            }
            catch(Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAllBanksAndCodes()
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAllBanksAndCodes = await _bankRepository.GetAllBanksAndBankCodesAsync();
                if(getAllBanksAndCodes == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Something went wrong";
                }
                response.Data = getAllBanksAndCodes;

            }catch(Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetBankByCBNCode(string BankCBNCode)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getBankByCBNCode = await _bankRepository.GetBankByCBNCode(BankCBNCode);
                if(getBankByCBNCode == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Bank record not found";
                }
                response.Data = getBankByCBNCode;
            }catch(Exception ex)
            {
                _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetBankById(int Id)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getBankById = await _bankRepository.GetBankById(Id);
                if(getBankById == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Bank record not found";
                }
                response.Data = getBankById;
            }catch(Exception ex)
            {
                _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
                
        }

        public async Task<Response> GetBankByShortCode(string BankShortCode)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getBankByShortCode = await _bankRepository.GetBankByShortCode(BankShortCode);
                if(getBankByShortCode == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Bank record not found";
                }
            }catch(Exception ex)
            {
                _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> UpdateBank(Bank bank)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                int updatedBank = await _bankRepository.UpdateBank(bank);
                if (updatedBank > 0)
                    response.Data = "Bank updated successfully";
                if(updatedBank < 0)
                    response.Data = "Bank does not exist";
                if(updatedBank == 0)
                {
                    _utilities.UnsuccessfulResponse(response, "Unable to Update Bank");
                }
                

            }catch(Exception ex)
            {
                _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }
    }
}
