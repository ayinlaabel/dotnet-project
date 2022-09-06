using Custodian.Salvage.Data.Dto.BidItemDomain;
using System.Data;
using Rds.Utilities.Database.ReadWrite;
using Dapper;

namespace Custodian.Salvage.Core.Helpers
{
    public static class BidItemHelper
    {
        public static BidItemDto GetBidItemById(IDbConnection db, int biditemId)
        {
            var storedProc = "dbo.gebiditem";
            var prm = new DynamicParameters();

            prm.Add("@bidItem", biditemId);

            var ls = DbStore.LoadData<BidItemDto>(db, storedProc, prm);

            if (ls != null && ls.Count == 1)
            {
                return ls[0];
            }

            throw new InvalidOperationException($"Item Id not available - {nameof(BidItemHelper)}");
        }

        public static List<BidItemDto> GetAllBidItem(IDbConnection db)
        {
            var storedProc = "dbo.gebiditem";

            return DbStore.LoadData<BidItemDto>(db, storedProc, new DynamicParameters());
        }
    }
}
