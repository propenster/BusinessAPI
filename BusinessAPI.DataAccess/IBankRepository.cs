using BusinessAPI.Domain;
using BusinessAPI.Domain.Bank;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.DataAccess
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetAllBanksAndBankCodesAsync();
        Task<Bank> GetBankById(int Id);
        Task<Bank> GetBankByCBNCode(string CBNCode);
        Task<Bank> GetBankByShortCode(string ShortCode);
        Task<int> AddBank(Bank bank);
        Task<int> UpdateBank(Bank bank);
        Task<int> DeleteBank(int Id);


    }
}
