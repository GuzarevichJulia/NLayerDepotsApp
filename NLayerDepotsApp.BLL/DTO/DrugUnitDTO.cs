using NLayerDepotsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.BLL.DTO
{
    public class DrugUnitDTO
    {
        public string DrugUnitId { get; set; }

        public int? DepotId { get; set; }

        public int DrugTypeId { get; set; }

        public bool Shipped { get; set; }

        public string DepotName { get; set; }

        public string DrugTypeName { get; set; }
    }
}
