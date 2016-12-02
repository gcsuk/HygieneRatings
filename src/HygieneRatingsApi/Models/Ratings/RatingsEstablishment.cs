using System;
using HygieneRatingsApi.Models.Ratings;

namespace HygieneRatings.Models.Ratings
{
    public class RatingsEstablishment
    {
        public string BusinessName { get; set; }
        public string PostCode { get; set; }
        public string RatingValue { get; set; }
        public string RatingKey { get; set; }
        public DateTime RatingDate { get; set; }
        public RatingsScores Scores { get; set; }
    }
}
