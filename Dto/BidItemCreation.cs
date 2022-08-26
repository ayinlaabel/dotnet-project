using Microsoft.AspNetCore.Http;

namespace salvage_portal.Dto
{
    public class BidItemCreation
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        //public string ImageUrl { get; set; }
        public List<IFormFile> file { get; set; }
        public string Sessions { get; set; }
        //public string CloseDate { get; set; }
    }
}