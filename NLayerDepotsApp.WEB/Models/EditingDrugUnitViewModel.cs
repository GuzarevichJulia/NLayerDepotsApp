using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NLayerDepotsApp.WEB.Models
{
    public class EditingDrugUnitViewModel
    {
        public SelectList DepotsList { get; set; }
        public string DrugUnitId { get; set; }
    }
}