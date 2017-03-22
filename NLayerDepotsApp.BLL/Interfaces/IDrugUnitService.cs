using NLayerDepotsApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NLayerDepotsApp.BLL.Interfaces
{
    public interface IDrugUnitService
    {
        IEnumerable<DrugUnitDTO> GetDrugUnits();
        DrugUnitDTO GetDrugUnit(string id);
        SelectList GetDepotsList();
        void Edit(DrugUnitDTO drugUnitDto);
        void Dispose();
    }
}
