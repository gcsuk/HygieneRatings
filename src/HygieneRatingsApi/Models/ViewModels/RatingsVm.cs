using System;

namespace HygieneRatings.Models.ViewModels
{
    public class RatingsVm
    {
        public string BusinessName { get; set; }
        public string BusinessPostCode { get; set; }
        public string Rating { get; set; }
        public DateTime RatingDate { get; set; }
        public string RatingKey { get; set; }
        public string HygieneScore { get; set; }
        public string StructuralScore { get; set; }
        public string ManagementScore { get; set; }
    }
}