using System.Data;
using System.Net.Http.Headers;
using Dapper;
using salvage_portal.Contracts;
using salvage_portal.Data;
using salvage_portal.Dto;
using salvage_portal.Models;

namespace salvage_portal.Repository
{
    public class BidItemRepository : IBidItemRepository
    {
        private readonly DapperContext _context;

        public BidItemRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<List<BidItem>> FetchBidItems()
        {
            var procedureName = "spFetchBidItems";
            using (var connection = _context.CreateConnection())
            {
                var BidItemDict = new Dictionary<int, BidItem>();

                var BidItems = await connection.QueryAsync<BidItem, BidItemImage, BidItem>(procedureName,
                    (bidItem, bidItemImage) =>
                    {
                        if(!BidItemDict.TryGetValue(bidItem.Id, out var currentBidItem))
                        {
                            currentBidItem = bidItem;
                            BidItemDict.Add(currentBidItem.Id, currentBidItem);
                        }
                        currentBidItem.Images.Add(bidItemImage);

                        return currentBidItem;
                    }
                    , commandType: CommandType.StoredProcedure);

                return BidItems.Distinct().ToList();
            }
        }

        public async Task<BidItem> GetBidItem(int id)
        {
            var procedureName = "spGetBidItem";
            var parameter = new DynamicParameters();
            parameter.Add("id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            using (var b = await connection.QueryMultipleAsync(procedureName, parameter, commandType: CommandType.StoredProcedure))
            {
                var bidItem = await b.ReadSingleOrDefaultAsync<BidItem>();
                if (bidItem is not null)
                    bidItem.Images = (await b.ReadAsync<BidItemImage>()).ToList();

                return bidItem;
            }

        }

        public async Task<BidItem> CreateBidItem(BidItemCreation bidItem)
        {
            var procedureName = "spSaveBidItem";
            var prodecureImageUpload = "spSaveBidItemImage";

            var parameters = new DynamicParameters();
            parameters.Add("Title", bidItem.Title, DbType.String);
            parameters.Add("Status", bidItem.Status, DbType.String);
            parameters.Add("State", bidItem.State, DbType.String);
            parameters.Add("Location", bidItem.Location, DbType.String);
            parameters.Add("Sessions", bidItem.Sessions, DbType.String);
            parameters.Add("CloseDate", DateTime.Now, DbType.String);
            parameters.Add("Created_At", DateTime.Now, DbType.DateTime2);
            parameters.Add("Updated_At", DateTime.Now, DbType.DateTime2);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var images = bidItem.file;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbPath = new BidItemImageDto();
                var im = new  DynamicParameters();
                for (int i = 0; i < images.Count; i++)
                {
                    im.Add("BidItem_ID", id, DbType.Int32);
                    var fileName = ContentDispositionHeaderValue.Parse(images[i].ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    dbPath.Image_URL = Path.Combine(folderName, fileName);
                    im.Add("image_URL", dbPath.Image_URL, DbType.String);

                    await connection.ExecuteAsync(prodecureImageUpload, im, commandType: CommandType.StoredProcedure);
                }

                var createdProduct = new BidItem()
                {
                    Id = id,
                    Title = bidItem.Title,
                    Status = bidItem.Status,
                    Location = bidItem.Location,
                    State = bidItem.State,
                    //ImageUrl = bidItem.ImageUrl,
                    //CloseDate = bidItem.CloseDate
                };

                return createdProduct;
            }
        }

        public async Task CreateBid(BidCreation bid)
        {
            var procedureName = "";

            var parameters = new DynamicParameters();
            parameters.Add("ProductId", bid.BidItemId, DbType.Int32);
            parameters.Add("FirstName", bid.FirstName, DbType.String);
            parameters.Add("LastName", bid.LastName, DbType.String);
            parameters.Add("Phone", bid.Phone, DbType.String);
            parameters.Add("Email", bid.Email, DbType.String);
            parameters.Add("Amount", bid.Amount, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}