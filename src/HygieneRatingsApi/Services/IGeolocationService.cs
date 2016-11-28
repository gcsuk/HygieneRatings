using System.Threading.Tasks;
using HygieneRatings.Models.Geolocation;

namespace HygieneRatings.Services
{
    public interface IGeolocationService
    {
        Task<GeolocationResults> GetCoordinates(string postCode);
    }
}