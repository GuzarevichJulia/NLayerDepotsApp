using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.BLL.DTO
{
    public class DepotDTO
    {
        public int DepotId { get; set; }
        
        public string DepotName { get; set; }

        public int? CountryId { get; set; }
    }
}
