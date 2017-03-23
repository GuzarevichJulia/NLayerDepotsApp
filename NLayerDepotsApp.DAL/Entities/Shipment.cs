using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Entities
{
    public class Shipment
    {
        public List<string> Shipped { get; set; }
        public Dictionary<string, int> Unshipped { get; set; }
    }
}
