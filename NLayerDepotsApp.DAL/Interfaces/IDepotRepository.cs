using NLayerDepotsApp.DAL.Entities;
using NLayerDepotsApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Interfaces
{
    public interface IDepotRepository
    {
        IQueryable<Depot> GetAll();
        Depot GetById(object id);
        void Create(Depot item);
        void Update(Depot item);
        void Delete(object id);
        IQueryable<WeightInfo> GetTypesWeight();
        IQueryable<DepotsInfo> GetDrugUnitsFromDepots();
        IEnumerable<QuantityDrugType> GetAvailableDrugTypesInDepot(int? depotId);
        Shipment Send(IEnumerable<QuantityDrugType> drugTypesInDepot, int depotId);
    }
}
