using Custodian.Salvage.DomainFacade.services;
using Microsoft.AspNetCore.Mvc;

namespace Custodian.Salvage.Api.Controllers
{
    [ApiController]
    [Route("api/biditem")]
    public class BidItemController : Controller
    {
        private readonly IPurchaseManager _purchaseManager;

        public BidItemController(IPurchaseManager purchaseManager)
        {
            _purchaseManager = purchaseManager;
        }

        [HttpGet]
        public IActionResult GetAllBidItem()
        {
            var bidItems = _purchaseManager.GetBidItems();

            return Ok(bidItems);
        }

    }
}
