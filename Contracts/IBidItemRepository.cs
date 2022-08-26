using salvage_portal.Dto;
using salvage_portal.Models;

namespace salvage_portal.Contracts
{
    public interface IBidItemRepository
    {
        public Task<List<BidItem>> FetchBidItems();
        public Task<BidItem> GetBidItem(int id);
        public Task<BidItem> CreateBidItem(BidItemCreation product);
        public Task CreateBid(BidCreation bid);
    }
}