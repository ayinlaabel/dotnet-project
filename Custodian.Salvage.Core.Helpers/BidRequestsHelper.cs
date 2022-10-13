using Custodian.Salvage.Data.Dto.BidDomain;
using Custodian.Salvage.Data.Dto.BidRequestDomain;
using Dapper;
using Rds.Utilities.Database.ReadWrite;
using System.Data;

namespace Custodian.Salvage.Core.Helpers
{
    public static class BidRequestsHelper
    {
        public static string CreateBidRequest(IDbConnection db, CreateBidRequestDto createBid)
        {
            //Store Procedures
            var findBidRequest = "spGetBidRequest";
            var findActiveBidRequest = "spGetActiveBidRequest";
            var updateBidRequest = "spUpdateBidRequest";
            var storedProc = "spSaveBidRequest";

            //Create Parameter to find
            var bid = new DynamicParameters();

            bid.Add("@Email", createBid.Email);
            bid.Add("@BidItemId", createBid.BidItemId);

            //Check for an exitingbid
            var exitingBid = DbStore.LoadData<BidRequestDto>(db, findBidRequest, bid);

            //Check if exiting bid is equals to 3
            if(exitingBid.Count == 3)
            {
                return "You have exhusted your maximum number of time to place bid request.";
            }
            else
            {
                var parameters = new DynamicParameters();

                if(exitingBid.Count < 1)
                {
                    var status = "active";
                    parameters.Add("@Email", createBid.Email);
                    parameters.Add("@BidItemId", createBid.BidItemId);
                    parameters.Add("@Narration", createBid.Narration);
                    parameters.Add("@BidValue", createBid.BidValue);
                    parameters.Add("@Status", status);
                    parameters.Add("@Created_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    parameters.Add("@Updated_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));


                    DbStore.SaveData(db, storedProc, parameters);
                    return "Created Successfullly!";
                }
                else
                {
                    //Updating the previous bidrequest status to cancelled
                    var updateBid = new DynamicParameters();
                    var activeBidRequest = DbStore.LoadData<BidRequestDto>(db, findActiveBidRequest, bid);
                    activeBidRequest[0].Status = "cancelled";

                    updateBid.Add("@Email", activeBidRequest[0].Email);
                    updateBid.Add("@Status", activeBidRequest[0].Status);
                    updateBid.Add("@BidItemId", activeBidRequest[0].BidItemId);
                    updateBid.Add("@Updated_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));

                    DbStore.SaveData(db, updateBidRequest, updateBid);



                    //Creating a new bidrequest after updating the previous bidrequest
                    var status = "active";
                    parameters.Add("@Email", createBid.Email);
                    parameters.Add("@BidItemId", createBid.BidItemId);
                    parameters.Add("@Narration", createBid.Narration);
                    parameters.Add("@BidValue", createBid.BidValue);
                    parameters.Add("@Status", status);
                    parameters.Add("@Created_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    parameters.Add("@Updated_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));

                    DbStore.SaveData(db, storedProc, parameters);

                    return "Created Successfullly!";
                }
            }
        }

        public static List<BidRequestDto> GetBidRequest(IDbConnection db , GetBidRequestDto bidRequest)
        {
            var storeProc = "spGetBidRequest";

            var parameters = new DynamicParameters();

            parameters.Add("@BidItemId", bidRequest.BidItemId);
            parameters.Add("@Email", bidRequest.Email);

            var retrievedBidRequest = DbStore.LoadData<BidRequestDto>(db, storeProc, parameters);

            return retrievedBidRequest;
        }
    }
}
