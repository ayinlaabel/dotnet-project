namespace salvage_portal.Models
{
    public class CreateProduct
    {
        public string title { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string closeDate { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public List<Object>? imageUrl { get; set; }
        // public string sessions { get; set; } = String.Empty;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}