using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Salvage.Data.Dto.LocationDomain
{
    public class LocationDto
    {
        public int id { get; set; }
        public string LocationAddress { get; set; } = String.Empty;
        public string LocationDescription { get; set; } = String.Empty;
    }
}
