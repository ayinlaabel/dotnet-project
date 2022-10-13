namespace Custodian.Salvage.Data.Dto.BidRequestDomain
{
    public class GetBidRequestDto
    {
        public int BidItemId { get; set; }
        public string Email { get; set; } = String.Empty;
    }
}
