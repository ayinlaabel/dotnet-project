namespace Custodian.Salvage.Data.Dto.BidItemDomain
{
    public class BidItemDto
    {
		public int BidItemId { get; set; }
		public DateTime BaselineCloseDate { get; set; }
		public DateTime DateCreated { get; set; }
		public int LocationId { get; set; }
		public string Title { get; set; } = string.Empty;
		public string LocationAddress { get; set; } = string.Empty;
		public string LocationDescription { get; set; }	= string.Empty;
	}
}
