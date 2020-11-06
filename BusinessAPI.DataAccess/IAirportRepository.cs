using BusinessAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.DataAccess
{
    public interface IAirportRepository
    {
        Task<IEnumerable<airports>> GetAllAirportsAsync();
        Task<airports> GetAirportByIdAsync(int id);
        Task<airports> GetAirportByNameAsync(string name);
        Task<airports> GetAirportByIATACodeAsync(string iata_code);
        Task<IEnumerable<airports>> GetAirportsByTypeAsync(string type);
        Task<airports> GetAirportByIdentAsync(string ident);
        Task<IEnumerable<airports>> GetAirportsByISOCountryAsync(string iso_country);
        Task<IEnumerable<airports>> GetAirportsByISORegionAsync(string iso_region);
        Task<airports> GetAirportNameByIATACodeAsync(string iata_code);
        Task<IEnumerable<airports>> GetAirportsByKeywordsAsync(string keywords);

        Task<int> AddAirport(airports airport);
        Task<int> UpdateAirport(airports airport);
        Task<int> DeleteAirport(int id);

    }
}
