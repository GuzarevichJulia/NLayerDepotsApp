using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class ShipmentViewModel
    {
        public List<string> Shipped { get; set; }
        public Dictionary<string, int> Unshipped { get; set; }
    }
}