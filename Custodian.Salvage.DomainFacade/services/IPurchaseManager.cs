using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidItemDomain;
using Custodian.Salvage.Data.Dto.LocationDomain;

namespace Custodian.Salvage.DomainFacade.services
{
    public interface IPurchaseManager
    {
        public List<BidItemDto> GetBidItems();
        public BidItemDto GetSignleBidItemById(int id);
        public List<BidItemDto> GetBidItemByStatus(string status);
        public string CreateBidItem(CreateBidItemDto createBidItem);
        public string CreateBid(CreateBidDto createBid);
    }
}
