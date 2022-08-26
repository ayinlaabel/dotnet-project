using Microsoft.AspNetCore.Mvc;
using salvage_portal.Contracts;
using salvage_portal.Dto;

namespace salvage_portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidItemController : Controller
    {
        private readonly IBidItemRepository _bidItemRepo;

        public BidItemController(IBidItemRepository bidItemRepo)
        {
            _bidItemRepo = bidItemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> FetchBidItems()
        {
            var bidItems = await _bidItemRepo.FetchBidItems();



            return Ok(bidItems);
        }

        [HttpGet]
        [Route("{id}", Name = "BidItemById")]
        public async Task<IActionResult> GetBidItem(int id)
        {
            var bidItem = await _bidItemRepo.GetBidItem(id);

            if (bidItem is null)
                return NotFound();

            return Ok(bidItem);
        }

        [HttpPost]
        public async Task<IActionResult> BidItemCreation([FromForm] BidItemCreation bidItem)
        {
            var createdBidItem = await _bidItemRepo.CreateBidItem(bidItem);

            return CreatedAtRoute("BidItemById", new { id = createdBidItem.Id }, createdBidItem);
        }

        [HttpPost]
        [Route("{id}/bid")]
        public async Task<IActionResult> BidCreation(BidCreation bid, [FromRoute] int id)
        {
            bid.BidItemId = id;
            await _bidItemRepo.CreateBid(bid);

            return Ok("Bid created successfully!");
        }
    }
}