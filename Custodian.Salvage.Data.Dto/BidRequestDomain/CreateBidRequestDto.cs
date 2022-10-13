namespace Custodian.Salvage.Data.Dto.BidDomain
{
    public class CreateBidRequestDto
    {
        public int BidItemId { get; set; }
        public string Email { get; set; } = String.Empty;
        public string Narration { get; set; } = String.Empty;
        public int BidValue { get; set; }
    }
}
