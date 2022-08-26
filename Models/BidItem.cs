using salvage_portal.Dto;

namespace salvage_portal.Models
{
    public class BidItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        //public string ImageUrl { get; set; }
        //public IFormFileCollection file { get; set; }
        public string Sessions { get; set; }
        //public string CloseDate { get; set; }
        public List<BidItemImage> Images { get; set; } = new List<BidItemImage>();
        //public List<Bid> Bidders { get; set; } = new List<Bid>();
    }
}