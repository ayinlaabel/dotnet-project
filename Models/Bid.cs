namespace salvage_portal.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int BidItemId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Amount { get; set; }
    }
}