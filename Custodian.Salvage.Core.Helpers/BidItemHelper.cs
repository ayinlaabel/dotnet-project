using Custodian.Salvage.Data.Dto.BidItemDomain;
using System.Data;
using Rds.Utilities.Database.ReadWrite;
using Dapper;
using System.Net.Http.Headers;

namespace Custodian.Salvage.Core.Helpers
{
    public static class BidItemHelper
    {
        public static BidItemDto GetSignleBidItemById(IDbConnection db, int biditemId)
        {
            var storedProc = "spGetBidItem";
            var imgStoredProc = "spGetBidItemImage";
            var parameter = new DynamicParameters();

            parameter.Add("@id", biditemId);

            var ls = DbStore.LoadData<BidItemDto>(db, storedProc, parameter);

            if (ls != null && ls.Count == 1)
            {
                var bidItem = ls[0];


                bidItem.Images.AddRange(DbStore.LoadData<BidItemImageDto>(db, imgStoredProc, parameter));

                return bidItem;
            }

            throw new InvalidOperationException($"Item Id not available - {nameof(BidItemHelper)}");
        }

        public static List<BidItemDto> GetAllBidItem(IDbConnection db)
        {
            var storedProc = "spFetchBidItems";
            var imgStoredProc = "spGetBidItemImage";

            var bidItems = DbStore.LoadData<BidItemDto>(db, storedProc, new DynamicParameters());

            foreach(var biditem in bidItems)
            {
                var bidItemImageId = new DynamicParameters();
                bidItemImageId.Add("@id", biditem.Id);
                var bidItemImages = DbStore.LoadData<BidItemImageDto>(db, imgStoredProc, bidItemImageId);
                biditem.Images.AddRange(bidItemImages);
            }

            return bidItems;
        }

        public static List<BidItemDto> GetBidItemByStatus(IDbConnection db, String status)
        {
            var storedProc = "spGetBidItemsByStatus";
            var parameter = new DynamicParameters();

            parameter.Add("@status", status);

            var filteredBidItem = DbStore.LoadData<BidItemDto>(db, storedProc, parameter);

            return filteredBidItem;
        }


        public static string CreateBidItem(IDbConnection db, CreateBidItemDto createBidItem)
        {
            var locationStoredProc = "spSaveLocation";
            var storedProc = "spSaveBidItem";
            var imageStoreProc = "";

            var parameters = new DynamicParameters();

            var images = createBidItem.file;

            var location = new DynamicParameters();

            //Saving Location to DB and Get the ID back
            location.Add("@locationAddress", createBidItem.LocationAddress);
            location.Add("@locationDescription", createBidItem.LocationDescription);

            location.Add("@locationId", direction: ParameterDirection.Output, dbType: DbType.Int32);

            DbStore.SaveData(db, locationStoredProc, location);
            var createdLocationId = location.Get<int>("@locationId");

            //Saving BidItem to DB
            parameters.Add("@title", createBidItem.Title);
            parameters.Add("@brand", createBidItem.Brand);
            parameters.Add("@model", createBidItem.Model);
            parameters.Add("@locationId", createdLocationId);
            parameters.Add("@created_At", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));
            parameters.Add("@close_Date", (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff"));
            parameters.Add("@bidItemId", direction: ParameterDirection.Output, dbType: DbType.Int32);

            DbStore.SaveData(db, storedProc, parameters);
            var createdBidItemId = parameters.Get<int>("@bidItemId");

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            for (int i = 0; i < images.Count; i++)
            {
                var img = new DynamicParameters();
                var image = images[i];
                var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                img.Add("@imageUrl", dbPath);
                img.Add("@BidItemId", createdBidItemId);

                DbStore.SaveData(db, imageStoreProc, img);
            }
            return "created successfully";
        }
    }
}
