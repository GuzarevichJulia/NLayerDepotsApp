using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Entities
{
    public class QuantityDrugType
    {
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public int Quantity { get; set; }
    }
}
