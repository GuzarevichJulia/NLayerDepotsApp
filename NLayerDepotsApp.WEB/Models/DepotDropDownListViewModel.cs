using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerDepotsApp.WEB.Models
{
    public class DepotDropDownListViewModel
    {
        public string DrugUnitId { get; set; }
        public int DepotId { get; set; }
        public List<SelectListItem> DepotsList { get; set; }
    }
}