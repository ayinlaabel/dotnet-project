using Custodian.Salvage.Data.Dto.BidDomain;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Custodian.Salvage.Core.Helpers
{
    public static class BidHelper
    {
        public static CreateBidDto CreateBid(IDbConnection db, CreateBidDto createBid)
        {
            var storedProc = "spSaveBid";
            var parameter = new DynamicParameters();

            parameter.Add("@FirstName", createBid.FirstName);
            parameter.Add("@LastName", createBid.LastName);
            parameter.Add("@Email", createBid.Email);
            parameter.Add("@Phone", createBid.Phone);
            parameter.Add("@Narration", createBid.Narration);
            parameter.Add("@BidValue", createBid.BidValue);


            DbStore.SaveData(db, storedProc, parameter);

            return createBid;
        }
    }
}
