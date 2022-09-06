using Custodian.Salvage.Data.Dto.BidItemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Salvage.DomainFacade.services
{
    public interface IPurchaseManager
    {
        List<BidItemDto> GetBidItems();
    }
}
