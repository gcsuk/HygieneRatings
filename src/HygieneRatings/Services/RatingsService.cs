using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HygieneRatings.Models.Ratings;
using Newtonsoft.Json;

namespace HygieneRatings.Services
{
    public class RatingsService : IRatingsService
    {
        public RatingsService()
        {

        }

        public async Task<RatingsEstablishments> GetRatings(string name, decimal latitude, decimal longitude)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.ratings.food.gov.uk/Establishments");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-version", "2");

                var response = await client.GetAsync($"?name={name}&longitude={longitude}&latitude={latitude}&maxDistanceLimit=10");

                return !response.IsSuccessStatusCode
                    ? null
                    : JsonConvert.DeserializeObject<RatingsEstablishments>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}