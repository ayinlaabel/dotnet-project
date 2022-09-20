using Custodian.Salvage.Data.Dto.BidDomain;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Custodian.Salvage.Core.Helpers
{
    public static class BidHelper
    {
        public static string CreateBid(IDbConnection db, CreateBidDto createBid)
        {
            var storedProc = "spSaveBid";
            var parameters = new DynamicParameters();

            parameters.Add("@FirstName", createBid.FirstName);
            parameters.Add("@LastName", createBid.LastName);
            parameters.Add("@Email", createBid.Email);
            parameters.Add("@Phone", createBid.Phone);
            parameters.Add("@BidItemId", createBid.BidItemId);
            parameters.Add("@Narration", createBid.Narration);
            parameters.Add("@BidValue", createBid.BidValue);
            parameters.Add("@Created_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));


            DbStore.SaveData(db, storedProc, parameters);

            return "Created Successfullly!";
        }
    }
}
