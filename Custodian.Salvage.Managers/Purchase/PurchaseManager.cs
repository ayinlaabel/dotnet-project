using Custodian.Salvage.Core.Helpers;
using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidItemDomain;
using Custodian.Salvage.DomainFacade.services;

namespace Custodian.Salvage.Managers.Purchase
{
    public class PurchaseManager : IPurchaseManager
    {
        private readonly string _connectionstring;

        public PurchaseManager(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<BidItemDto> GetBidItems()
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionstring);

            return BidItemHelper.GetAllBidItem(db);
        }
        public BidItemDto GetSignleBidItemById(int id)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionstring);

            return BidItemHelper.GetSignleBidItemById(db, id);
        }

        public List<BidItemDto> GetBidItemByStatus(string status)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionstring);

            return BidItemHelper.GetBidItemByStatus(db, status);
        }

        public string CreateBidItem(CreateBidItemDto createBidItem)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionstring);

            return BidItemHelper.CreateBidItem(db, createBidItem);
        }

        public string CreateBid(CreateBidDto createBid)
        {
            using var db = DatabaseHelper.OpenDatabase(_connectionstring);

            return BidHelper.CreateBid(db, createBid);
        }
    }
}
