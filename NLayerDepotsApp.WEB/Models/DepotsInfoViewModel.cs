﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class DepotsInfoViewModel
    {
        public string DepotName { get; set; }
        public string CountryName { get; set; }
        public string DrugTypeName { get; set; }
        public string DrugUnitId { get; set; }
        public int PickNumber { get; set; }
    }
}