using System;

namespace HygieneRatings.Models.Ratings
{
    public class RatingsEstablishment
    {
        public string BusinessName { get; set; }
        public string PostCode { get; set; }
        public int RatingValue { get; set; }
        public string RatingKey { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
