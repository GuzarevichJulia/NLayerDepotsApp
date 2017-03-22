using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class QuantityDrugTypeViewModel
    {
        public int DrugTypeId { get; set; }
        public string DrugTypeName { get; set; }
        public int Quantity { get; set; }
    }
}