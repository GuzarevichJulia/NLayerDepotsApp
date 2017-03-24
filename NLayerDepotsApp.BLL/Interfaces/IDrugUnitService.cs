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
        IEnumerable<DrugUnitDTO> GetDrugUnits(int skipCount = 0, int? drugUnitCount = null);
        DrugUnitDTO GetDrugUnit(string id);
        int GetDrugUnitsCount();
        SelectList GetDepotsList();
        void Edit(DrugUnitDTO drugUnitDto);
        void Dispose();
    }
}
