using Microsoft.AspNetCore.Http;

namespace salvage_portal.Dto
{
    public class UploadImage
    {
        public int BidItem_Id{ get; set; }  
        public IFormFile Image { get; set; }
    }
}