using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class DrugTypesInDepotViewModel
    {
        public int DepotId { get; set; }
        public List<QuantityDrugTypeViewModel> AvailableDrugTypes { get; set; }
    }
}