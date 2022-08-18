namespace salvage_portal.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        // public Object session { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}