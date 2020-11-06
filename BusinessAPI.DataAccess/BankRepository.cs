using BusinessAPI.Domain.Bank;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessAPI.DataAccess
{
    public class BankRepository : IBankRepository
    {
        private readonly IConfiguration _config;

        public BankRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("AirportConnection"));
            }
        }

        public async Task<int> AddBank(Bank bank)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@BankName", bank.BankName);
                    parameters.Add("@BankCBNCode", bank.BankCBNCode);
                    parameters.Add("@BankShortCode", bank.BankShortCode);

                    return await SqlMapper.ExecuteAsync(dbConnection, "AddBank", param: parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteBank(int Id)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    return await SqlMapper.ExecuteAsync(dbConnection, "DeleteBank", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Bank>> GetAllBanksAndBankCodesAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await SqlMapper.QueryAsync<Bank>(dbConnection, "GetAllBanks", commandType: CommandType.StoredProcedure);

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bank> GetBankByCBNCode(string CBNCode)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@BankCBNCode", CBNCode);
                    return await SqlMapper.QueryFirstOrDefaultAsync<Bank>(dbConnection, "GetBankByCBNCode", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bank> GetBankById(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    return await SqlMapper.QueryFirstOrDefaultAsync<Bank>(dbConnection, "GetBankById", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bank> GetBankByShortCode(string ShortCode)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@BankShortCode", ShortCode);
                    return await SqlMapper.QueryFirstOrDefaultAsync<Bank>(dbConnection, "GetBankByShortCode", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateBank(Bank bank)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", bank.Id);
                    parameters.Add("@BankName", bank.BankName);
                    parameters.Add("@BankCBNCode", bank.BankCBNCode);
                    parameters.Add("@BankShortCode", bank.BankShortCode);

                    return await SqlMapper.ExecuteAsync(dbConnection, "UpdateBank", param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
