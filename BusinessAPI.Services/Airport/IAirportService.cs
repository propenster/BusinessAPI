using BusinessAPI.DataAccess;
using BusinessAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services.Airport
{
    public interface IAirportService
    {

        Task<Response> GetAllAirports();
        Task<Response> GetAirportById(int id);
        Task<Response> GetAirportByName(string name);
        Task<Response> GetAirportByIATACode(string iata_code);
        Task<Response> GetAirportsByType(string type);
        Task<Response> GetAirportByIdent(string ident);
        Task<Response> GetAirportsByISOCountry(string iso_country);
        Task<Response> GetAirportsByISORegion(string iso_region);
        Task<Response> GetAirportNameByIATACode(string iata_code);
        Task<Response> GetAirportsByKeywords(string keywords);
        Task<Response> AddAirport(airports airport);
        Task<Response> UpdateAirport(airports airport);
        Task<Response> DeleteAirport(int id);

    }
}
