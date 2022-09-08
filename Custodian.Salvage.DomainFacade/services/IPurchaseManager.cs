using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidItemDomain;

namespace Custodian.Salvage.DomainFacade.services
{
    public interface IPurchaseManager
    {
        public List<BidItemDto> GetBidItems();
        public CreateBidDto CreateBid(CreateBidDto createBid);
    }
}
