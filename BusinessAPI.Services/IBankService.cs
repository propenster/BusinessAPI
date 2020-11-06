using BusinessAPI.Domain;
using BusinessAPI.Domain.Bank;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services
{
    public interface IBankService
    {
        Task<Response> GetAllBanksAndCodes();
        Task<Response> GetBankById(int Id);
        Task<Response> GetBankByCBNCode(string BankCBNCode);
        Task<Response> GetBankByShortCode(string BankShortCode);
        Task<Response> AddBank(Bank bank);
        Task<Response> UpdateBank(Bank bank);
        Task<Response> DeleteBank(int Id);


    }
}
