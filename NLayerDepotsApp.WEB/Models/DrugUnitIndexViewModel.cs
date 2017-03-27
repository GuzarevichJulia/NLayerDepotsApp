using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NLayerDepotsApp.WEB.Models
{
    public class DrugUnitIndexViewModel
    {
        public IEnumerable<DrugUnitViewModel> DrugUnits { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
        public SelectList DepotsList { get; set; }
    }
}