using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class WeightInfoViewModel
    {
        public string DepotName { get; set; }
        public string DrugTypeName { get; set; }
        public double DrugTypeWeight { get; set; }
        public double TotalWeight { get; set; }
        public int Count { get; set; }
    }
}