namespace Custodian.Salvage.Data.Dto.BidItemDomain
{
    public class BidItemDto
    {
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Regno { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ContactPerson { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string Address { get; set; }	= string.Empty;
		public DateTime Close_Date { get; set; }
        public List<BidItemImageDto> Images { get; set; } = new List<BidItemImageDto>();
    }
}
