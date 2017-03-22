using NLayerDepotsApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.BLL.Interfaces
{
    public interface IDepotService
    {
        IEnumerable<DepotDTO> GetDepots();
        DepotDTO GetDepot(int id);
        IEnumerable<DepotsInfoDTO> GetDepotsInfo();
        IEnumerable<WeightInfoDTO> GetWeightInfo();
        IEnumerable<QuantityDrugTypeDTO> GetDrugTypesInDepot(int? id);
    }
}
