using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class ShipmentViewModel
    {
        public List<string> ShippedList { get; set; }
        public Dictionary<string, int> UnshippedDictionary { get; set; }
    }
}