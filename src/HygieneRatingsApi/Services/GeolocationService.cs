using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HygieneRatings.Models.Geolocation;
using Newtonsoft.Json;

namespace HygieneRatings.Services
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<GeolocationResults> GetCoordinates(string address)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"?address={address}");

                return JsonConvert.DeserializeObject<GeolocationResults>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}