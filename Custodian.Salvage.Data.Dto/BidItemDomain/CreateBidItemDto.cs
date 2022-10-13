using Microsoft.AspNetCore.Http;

namespace Custodian.Salvage.Data.Dto.BidItemDomain
{
    public class CreateBidItemDto
    {
		public DateTime Close_Date { get; set; }
		public DateTime Created_At { get; set; }
		public int LocationId { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Brand { get; set; } = string.Empty;
		public string Model { get; set; } = string.Empty;
		public string LocationAddress { get; set; } = string.Empty;
		public string LocationDescription { get; set; } = string.Empty;
		public List<IFormFile> file { get; set; } = new List<IFormFile>();
	}
}
