using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HygieneRatings.Models.ViewModels;
using HygieneRatings.Services;
using Microsoft.AspNetCore.Mvc;

namespace HygieneRatings.Controllers
{
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private readonly IRatingsService _ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            _ratingsService = ratingsService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string name, decimal lat, decimal lng)
        {
            var results = await _ratingsService.GetRatings(name, lat, lng);

            if (results == null)
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
