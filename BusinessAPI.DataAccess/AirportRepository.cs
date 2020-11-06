using BusinessAPI.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.DataAccess
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IConfiguration _configuration;

        public AirportRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("AirportConnection"));
            }
        }

        public async Task<int> AddAirport(airports airport)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ident", airport.ident);
                    parameters.Add("@type", airport.type);
                    parameters.Add("@name", airport.name);
                    parameters.Add("@latitude_deg", airport.latitude_deg);
                    parameters.Add("@longitude_deg", airport.longitude_deg);
                    parameters.Add("@elevation.ft", airport.elevation_ft);
                    parameters.Add("@continent", airport.continent);
                    parameters.Add("@iso_country", airport.iso_country);
                    parameters.Add("@iso_region", airport.iso_region);
                    parameters.Add("@municipality", airport.municipality);
                    parameters.Add("@scheduled_service", airport.scheduled_service);
                    parameters.Add("@gps_code", airport.gps_code);
                    parameters.Add("@iata_code", airport.iata_code);
                    parameters.Add("@local_code", airport.local_code);
                    parameters.Add("@home_link", airport.home_link);
                    parameters.Add("@wikipedia_link", airport.wikipedia_link);
                    parameters.Add("@keywords", airport.keywords);

                    return await SqlMapper.ExecuteAsync(dbConnection, "AddAirport", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAirport(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    return await SqlMapper.ExecuteAsync(dbConnection, "DeleteAirport", parameters, commandType: CommandType.StoredProcedure);

                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<airports> GetAirportByIATACodeAsync(string iata_code)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@iata_code", iata_code);
                    return await SqlMapper.QueryFirstOrDefaultAsync<airports>(dbConnection, "GetAirportByIATACode", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<airports> GetAirportByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@id", id);
                    return await SqlMapper.QueryFirstOrDefaultAsync<airports>(dbConnection, "GetAirportById", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<airports> GetAirportByNameAsync(string name)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@name", name);
                    return await SqlMapper.QueryFirstOrDefaultAsync<airports>(dbConnection, "GetAirportByName", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<airports> GetAirportNameByIATACodeAsync(string iata_code)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@iata_code", iata_code);
                    return await SqlMapper.QueryFirstOrDefaultAsync<airports>(dbConnection, "GetAirportNameByIATACode", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<airports> GetAirportByIdentAsync(string ident)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ident", ident);
                    return await SqlMapper.QueryFirstOrDefaultAsync<airports>(dbConnection, "GetAirportByIdent", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<airports>> GetAirportsByISOCountryAsync(string iso_country)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@iso_country", iso_country);
                    return await SqlMapper.QueryAsync<airports>(dbConnection, "GetAirportsByISOCountry", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<airports>> GetAirportsByISORegionAsync(string iso_region)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@iso_region", iso_region);
                    return await SqlMapper.QueryAsync<airports>(dbConnection, "GetAirportsByISORegion", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<airports>> GetAirportsByTypeAsync(string type)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@type", type);
                    return await SqlMapper.QueryAsync<airports>(dbConnection, "GetAirportsByType", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<airports>> GetAllAirportsAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await SqlMapper.QueryAsync<airports>(dbConnection, "GetAllAirports", commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAirport(airports airport)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ident", airport.ident);
                    parameters.Add("@type", airport.type);
                    parameters.Add("@name", airport.name);
                    parameters.Add("@latitude_deg", airport.latitude_deg);
                    parameters.Add("@longitude_deg", airport.longitude_deg);
                    parameters.Add("@elevation.ft", airport.elevation_ft);
                    parameters.Add("@continent", airport.continent);
                    parameters.Add("@iso_country", airport.iso_country);
                    parameters.Add("@iso_region", airport.iso_region);
                    parameters.Add("@municipality", airport.municipality);
                    parameters.Add("@scheduled_service", airport.scheduled_service);
                    parameters.Add("@gps_code", airport.gps_code);
                    parameters.Add("@iata_code", airport.iata_code);
                    parameters.Add("@local_code", airport.local_code);
                    parameters.Add("@home_link", airport.home_link);
                    parameters.Add("@wikipedia_link", airport.wikipedia_link);
                    parameters.Add("@keywords", airport.keywords);

                    return await SqlMapper.ExecuteAsync(dbConnection, "UpdateAirport", param: parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<airports>> GetAirportsByKeywordsAsync(string keywords)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@keywords", keywords);
                    return await SqlMapper.QueryAsync<airports>(dbConnection, "GetAirportsByKeywords", parameters, commandType: CommandType.StoredProcedure);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
