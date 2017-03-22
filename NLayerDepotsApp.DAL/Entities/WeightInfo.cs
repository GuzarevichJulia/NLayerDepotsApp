using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Entities
{
    public class WeightInfo
    {
        public string DepotName { get; set; }
        public string DrugTypeName { get; set; }
        public double DrugTypeWeight { get; set; }
        public double TotalWeight { get; set; }
        public int Count { get; set; }
    }
}
