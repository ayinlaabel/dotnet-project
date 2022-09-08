namespace Custodian.Salvage.Data.Dto.BidDomain
{
    public class CreateBidDto
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public string Phone { get; set;} = String.Empty;
        public string Narration { get; set; } = String.Empty;
        public string BidValue { get; set; } = String.Empty;
    }
}
