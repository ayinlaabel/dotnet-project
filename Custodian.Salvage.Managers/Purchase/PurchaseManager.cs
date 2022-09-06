using Custodian.Salvage.Core.Helpers;
using Custodian.Salvage.Data.Dto.BidItemDomain;
using Custodian.Salvage.DomainFacade.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
