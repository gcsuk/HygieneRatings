using System;
using System.Linq;
using System.Threading.Tasks;
using HygieneRatings.Models.ViewModels;
using HygieneRatings.Services;
using Microsoft.AspNetCore.Mvc;

namespace HygieneRatings.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GeolocationController : Controller
    {
        private readonly IGeolocationService _geolocationService;

        public GeolocationController(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        /// <remarks>Returns the geolocation of a given post code</remarks>
        /// <response code="200">Returns the location</response>
        /// <response code="404">The specified post code was not found</response>
        /// <response code="500">Unexpected error</response>
        /// <returns>A geolocatrion object</returns>
        [HttpGet("{postCode}")]
        [ProducesResponseType(typeof(GeolocationVm), 200)]
        public async Task<IActionResult> Get(string postCode)
        {
            try
            {
                var results = await _geolocationService.GetCoordinates(postCode.Replace(" ", "").ToUpper());

                if (results == null || !results.Results.Any())
                {
                    return NotFound();
                }

                return Ok(new GeolocationVm
                {
                    PostCode = postCode,
                    Latitude = results.Results.FirstOrDefault().Geometry.Location.Latitude,
                    Longitude = results.Results.FirstOrDefault().Geometry.Location.Longitude
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
