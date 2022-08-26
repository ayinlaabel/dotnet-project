using Microsoft.AspNetCore.Http;

namespace salvage_portal.Dto
{
    public class MultiUploadImage
    {
        public List<IFormFile> Images { get; set; }
    }
}