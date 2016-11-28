using Newtonsoft.Json;

namespace HygieneRatings.Models.Geolocation
{
    public class GeolocationLocation
    {
        [JsonProperty("lng")]
        public decimal Longitude { get; set; }
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
    }
}