﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerDepotsApp.WEB.Models
{
    public class DrugUnitViewModel
    {
        public string DrugUnitId { get; set; }

        public int DepotId { get; set; }

        public string DepotName { get; set; }

        public string DrugTypeName { get; set; }
    }
}