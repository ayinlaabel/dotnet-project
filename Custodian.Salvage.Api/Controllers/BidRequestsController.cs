using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidRequestDomain;
using Custodian.Salvage.DomainFacade.services;
using Microsoft.AspNetCore.Mvc;

namespace Custodian.Salvage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidRequestsController : Controller
    {
        private readonly IPurchaseManager _purchaseManager;

        public BidRequestsController(IPurchaseManager purchaseManager)
        {
            _purchaseManager = purchaseManager;
        }

        [HttpGet]
        public IActionResult GetBidRequest(GetBidRequestDto bidRequest)
        {
            var retrievedBidRequest = _purchaseManager.GetBidRequest(bidRequest);

            return Ok(retrievedBidRequest);
        }

        [HttpPost]
        public IActionResult CreateBidRequest(CreateBidRequestDto createBid)
        {

            var createdBid = _purchaseManager.CreateBidRequest(createBid);

            return Ok(createdBid);
        }
    }
}
