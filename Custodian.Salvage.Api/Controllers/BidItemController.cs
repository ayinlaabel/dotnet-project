using Custodian.Salvage.Api.Configurations;
using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidItemDomain;
using Custodian.Salvage.Data.Dto.LocationDomain;
using Custodian.Salvage.DomainFacade.services;
using Microsoft.AspNetCore.Mvc;

namespace Custodian.Salvage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleBidItemById(int id)
        {
            var bidItem = _purchaseManager.GetSignleBidItemById(id);

            return Ok(bidItem);
        }

        [HttpGet]
        [Route("filterby")]
        public IActionResult GetBidItemByStatus(string status)
        {
            var filterBidItems = _purchaseManager.GetBidItemByStatus(status);

            return Ok(filterBidItems);

        }


        [HttpPost]
        public IActionResult CreateBidItem([FromForm] CreateBidItemDto createBidItem)
        {    
            var createdBidItem = _purchaseManager.CreateBidItem(createBidItem);

            return Ok(createdBidItem);
        }


        [HttpPost]
        [Route("{id}/bid")]
        public IActionResult CreateBid(int id, CreateBidRequestDto createBid)
        {
            createBid.BidItemId = id;

            var createdBid = _purchaseManager.CreateBidRequest(createBid);

            return Ok(createdBid);
        }

    }
}
