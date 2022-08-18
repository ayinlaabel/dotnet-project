namespace salvage_portal.Models
{
    public class CreateBidder
    {
        public string firstName { get; set; } = String.Empty;
        public string lastName { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public string role { get; set; } = String.Empty;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}