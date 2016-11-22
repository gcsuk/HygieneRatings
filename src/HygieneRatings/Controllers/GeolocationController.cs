using System.Linq;
using System.Threading.Tasks;
using HygieneRatings.Models.ViewModels;
using HygieneRatings.Services;
using Microsoft.AspNetCore.Mvc;

namespace HygieneRatings.Controllers
{
    [Route("api/[controller]")]
    public class GeolocationController : Controller
    {
        private readonly IGeolocationService _geolocationService;

        public GeolocationController(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string postCode)
        {
            var results = await _geolocationService.GetCoordinates(postCode.Replace(" ", "").ToUpper());

            if (results == null)
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
    }
}
