namespace Custodian.Salvage.Data.Dto.BidDomain
{
    public class BidRequestDto
    {
        public int Id { get; set; }
        public int BidItemId { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
        public string Narration { get; set; } = String.Empty;
        public int BidValue { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}
