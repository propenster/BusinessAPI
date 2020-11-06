using BusinessAPI.Domain;
using BusinessAPI.Services.Airport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportsController : ControllerBase
    {
        protected readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAirports()
        {
            var airports = await _airportService.GetAllAirports();
            return Ok(airports);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportById(int id)
        {
            var airport = await _airportService.GetAirportById(id);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportByIATACode(string iata_code)
        {
            var airport = await _airportService.GetAirportByIATACode(iata_code);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportsByType(string type)
        {
            var airport = await _airportService.GetAirportsByType(type);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportByIdent(string ident)
        {
            var airport = await _airportService.GetAirportByIdent(ident);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportsByISOCountry(string iso_country)
        {
            var airport = await _airportService.GetAirportsByISOCountry(iso_country);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportsByISORegion(string iso_region)
        {
            var airport = await _airportService.GetAirportsByISORegion(iso_region);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportNameByIATACode(string iata_code)
        {
            var airport = await _airportService.GetAirportNameByIATACode(iata_code);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportByName(string name)
        {
            var airport = await _airportService.GetAirportByName(name);
            return Ok(airport);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAirportsByKeywords(string keywords)
        {
            var airports = await _airportService.GetAirportsByKeywords(keywords);
            return Ok(airports);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAirport([FromBody] airports airport)
        {
            if (ModelState.IsValid)
            {
                _airportService.AddAirport(airport);
                return CreatedAtAction(nameof(GetAirportById), new { id = airport.id }, airport);

            }
            return BadRequest();
        }

        [Route("[action]")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAirport(int id)
        {
            _airportService.DeleteAirport(id);
            return Ok();
        }

        [Route("[action]")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateAirport([FromBody] airports airport)
        {
            if (ModelState.IsValid)
            {
                _airportService.UpdateAirport(airport);
                return Ok();
            }
            return BadRequest();
        }



    }
}
