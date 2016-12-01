using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HygieneRatings.Models.ViewModels;
using HygieneRatings.Services;
using Microsoft.AspNetCore.Mvc;

namespace HygieneRatings.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RatingsController : Controller
    {
        private readonly IRatingsService _ratingsService;
        private readonly IGeolocationService _geolocationService;

        public RatingsController(IRatingsService ratingsService, IGeolocationService geolocationService)
        {
            _ratingsService = ratingsService;
            _geolocationService = geolocationService;
        }

        /// <remarks>Returns all matching businesses for specified name and location</remarks>
        /// <response code="200">Returns the ratings</response>
        /// <response code="404">No ratings were found for the specified name and co-ordinates</response>
        /// <response code="500">Unexpected error</response>
        /// <returns>A list of rating objects</returns>
        [HttpGet("{name}/{postCode}")]
        [ProducesResponseType(typeof(IEnumerable<RatingsVm>), 200)]
        public async Task<IActionResult> Get(string name, string address)
        {
            var geolocationResults = await _geolocationService.GetCoordinates(address);

            if (geolocationResults == null || !geolocationResults.Results.Any())
            {
                return NotFound();
            }

            var geolocation = geolocationResults.Results.First().Geometry.Location;

            var results = await _ratingsService.GetRatings(name, geolocation.Latitude, geolocation.Longitude);

            if (results == null || !results.Establishments.Any())
            {
                return NotFound();
            }

            return
                Ok(new List<RatingsVm>(
                    results.Establishments.Select(
                        e =>
                            new RatingsVm
                            {
                                BusinessName = e.BusinessName,
                                BusinessPostCode = e.PostCode,
                                Rating = e.RatingValue,
                                RatingDate = e.RatingDate,
                                RatingKey = e.RatingKey
                            })));
        }

        /// <remarks>Returns all matching businesses for specified name and location</remarks>
        /// <response code="200">Returns the ratings</response>
        /// <response code="404">No ratings were found for the specified name and co-ordinates</response>
        /// <response code="500">Unexpected error</response>
        /// <returns>A list of rating objects</returns>
        [HttpGet("{name}/{lat}/{lng}")]
        [ProducesResponseType(typeof(IEnumerable<RatingsVm>), 200)]
        public async Task<IActionResult> Get(string name, decimal lat, decimal lng)
        {
            var results = await _ratingsService.GetRatings(name, lat, lng);

            if (results == null || !results.Establishments.Any())
            {
                return NotFound();
            }

            return
                Ok(new List<RatingsVm>(
                    results.Establishments.Select(
                        e =>
                            new RatingsVm
                            {
                                BusinessName = e.BusinessName,
                                BusinessPostCode = e.PostCode,
                                Rating = e.RatingValue,
                                RatingDate = e.RatingDate,
                                RatingKey = e.RatingKey
                            })));
        }
    }
}
