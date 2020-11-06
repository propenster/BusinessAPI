using BusinessAPI.DataAccess;
using BusinessAPI.Domain;
using BusinessAPI.Domain.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAPI.Services.Airport
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly ILogger<AirportService> _logger;
        private readonly Utilities _utilities;
        private static AirportAPISettings _settings;

        public AirportService(IAirportRepository airportRepository, ILogger<AirportService> logger, IOptions<AirportAPISettings> settings)
        {
            _airportRepository = airportRepository;
            _logger = logger;
            _utilities = new Utilities(logger);
            _settings = settings.Value;
        }

        public async Task<Response> GetAllAirports()
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAllAirports = await _airportRepository.GetAllAirportsAsync();
                response.Data = getAllAirports;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");

            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY =>  REQUEST ID => {response.RequestId}");
            }
            return response;

        }

        public async Task<Response> GetAirportById(int id)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportById = await _airportRepository.GetAirportByIdAsync(id);
                if (getAirportById == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Record not found";
                }
                response.Data = getAirportById;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");

            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");

            }
            return response;
        }

        public async Task<Response> GetAirportByName(string name)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportByName = await _airportRepository.GetAirportByNameAsync(name);
                if (getAirportByName == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Record not found";
                }
                response.Data = getAirportByName;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportByIATACode(string iata_code)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportByIATACode = await _airportRepository.GetAirportByIATACodeAsync(iata_code);
                if (getAirportByIATACode == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Record not found";
                }
                response.Data = getAirportByIATACode;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportsByType(string type)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportsByType = await _airportRepository.GetAirportsByTypeAsync(type);
                response.Data = getAirportsByType;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportByIdent(string ident)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportByIdent = await _airportRepository.GetAirportByIdentAsync(ident);
                if (getAirportByIdent == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Record not found";
                }
                response.Data = getAirportByIdent;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportsByISOCountry(string iso_country)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportsByISOCountry = await _airportRepository.GetAirportsByISOCountryAsync(iso_country);
                if (getAirportsByISOCountry == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Invalid ISO_COUNTRY code or Record not found";
                }
                response.Data = getAirportsByISOCountry;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportsByISORegion(string iso_region)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportsByISORegion = await _airportRepository.GetAirportsByISORegionAsync(iso_region);
                if (getAirportsByISORegion == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Invalid ISO_REGION code or Record not found";
                }
                response.Data = getAirportsByISORegion;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportNameByIATACode(string iata_code)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportsByIATACode = await _airportRepository.GetAirportNameByIATACodeAsync(iata_code);
                if (getAirportsByIATACode == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "Record not found";
                }
                response.Data = getAirportsByIATACode;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> AddAirport(airports airport)
        {

            Response response = _utilities.InitializeResponse();
            try
            {
                int addedAirport = await _airportRepository.AddAirport(airport);
                if (addedAirport > 0)
                    response.Data = "Airport Saved Sucessfully!";
                if (addedAirport == 0)
                {
                    return _utilities.UnsuccessfulResponse(response, "Unable to Save Airport");
                }
            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> UpdateAirport(airports airport)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> DeleteAirport(int id)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                int addedAirport = await _airportRepository.DeleteAirport(id);
                if (addedAirport > 0)
                    response.Data = "Airport Deleted Successfully";
                if (addedAirport < 0)
                    response.Data = "Airport Does not Exist";
                if (addedAirport == 0)
                {
                    return _utilities.UnsuccessfulResponse(response, "Unable to Delete Beneficiary");
                }


            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }

        public async Task<Response> GetAirportsByKeywords(string keywords)
        {
            Response response = _utilities.InitializeResponse();
            try
            {
                var getAirportsByKeywords = await _airportRepository.GetAirportsByKeywordsAsync(keywords);
                if (getAirportsByKeywords == null)
                {
                    response.ResponseCode = "99";
                    response.ResponseMessage = "No Airport matching the keyword";
                }
                response.Data = getAirportsByKeywords;
                _logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");

            }
            catch (Exception ex)
            {
                response = _utilities.CatchException(response);
                _logger.LogError($"{ex.Message} REQUEST BODY => REQUEST ID => {response.RequestId}");
            }
            return response;
        }
    }
}
