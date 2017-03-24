using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Models
{
    public class Shipment
    {
        public List<string> ShippedList { get; set; }
        public Dictionary<string, int> UnshippedDictionary { get; set; }
    }
}
