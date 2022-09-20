namespace Custodian.Salvage.Data.Dto.BidItemDomain
{
    public class BidItemDto
    {
		public int Id { get; set; }
		public DateTime Close_Date { get; set; }
		public DateTime Created_At { get; set; }
		public int LocationId { get; set; }
		public string Title { get; set; } = string.Empty;
		public string LocationAddress { get; set; } = string.Empty;
		public string LocationDescription { get; set; }	= string.Empty;
		//public List<BidImageDto> Images { get; set; } = new List<BidImageDto>();
	}
}
