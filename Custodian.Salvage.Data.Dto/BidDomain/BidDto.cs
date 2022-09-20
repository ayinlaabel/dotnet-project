namespace Custodian.Salvage.Data.Dto.BidDomain
{
    public class BidDto
    {
        public int Id { get; set; }
        public int BidItemId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set;  } = String.Empty;
        public string Narration { get; set; } = String.Empty;
        public int BidValue { get; set; }
    }
}
