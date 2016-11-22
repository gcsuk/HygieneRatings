using HygieneRatings.Models.Ratings;
using System.Threading.Tasks;

namespace HygieneRatings.Services
{
    public interface IRatingsService
    {
        Task<RatingsEstablishments> GetRatings(string name, decimal latitude, decimal longitude);
    }
}