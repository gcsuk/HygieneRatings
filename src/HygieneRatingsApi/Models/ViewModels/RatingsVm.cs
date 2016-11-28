using System;

namespace HygieneRatings.Models.ViewModels
{
    public class RatingsVm
    {
        public string BusinessName { get; set; }
        public string BusinessPostCode { get; set; }
        public int Rating { get; set; }
        public DateTime RatingDate { get; set; }
        public string RatingKey { get; set; }
    }
}