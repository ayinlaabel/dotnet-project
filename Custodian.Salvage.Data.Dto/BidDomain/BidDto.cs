namespace Custodian.Salvage.Data.Dto.BidDomain
{
    public class BidDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Narration { get; set; } = string.Empty;
        public int BidValue { get; set; }

    }
}
