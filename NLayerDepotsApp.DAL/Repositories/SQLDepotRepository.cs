using NLayerDepotsApp.DAL.EF;
using NLayerDepotsApp.DAL.Entities;
using NLayerDepotsApp.DAL.Models;
using NLayerDepotsApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Repositories
{
    public class SQLDepotRepository : SQLBaseRepository<Depot>, IDepotRepository
    {
        public SQLDepotRepository(DrugsContext context) : base(context)
        {
            dbSet = db.Depot;
        }     
          
        public IQueryable<WeightInfo> GetTypesWeight()
        {
            return from du in db.DrugUnit
                   where du.DepotId != null
                   group new { du.Depot.DepotId, du.DrugType.DrugTypeId, du.DrugUnitId} by new
                   {
                       du.Depot.DepotName,
                       du.DrugType.DrugTypeName,
                       du.DrugType.DrugTypeWeight
                   } into g
                   select new WeightInfo()
                   {
                       DepotName = g.Key.DepotName,
                       DrugTypeName = g.Key.DrugTypeName,
                       DrugTypeWeight = g.Key.DrugTypeWeight,
                       Count = g.Count(p => p.DrugUnitId != null)
                   };
        }

        public IQueryable<DepotsInfo> GetDrugUnitsFromDepots()
        {
            return from depot in dbSet
                   join drugUnit in db.DrugUnit
                   on depot.DepotId equals drugUnit.DepotId into Joined
                   from drugUnit in Joined.DefaultIfEmpty()
                   select new DepotsInfo
                   {
                       DepotName = depot.DepotName,
                       CountryName = depot.Country.CountryName,
                       DrugTypeName = drugUnit.DrugType.DrugTypeName,
                       PickNumber = drugUnit.PickNumber,
                       DrugUnitId = drugUnit != null ? drugUnit.DrugUnitId : null
                   };
        }

        public IEnumerable<QuantityDrugType> GetAvailableDrugTypesInDepot(int? depotId)
        {
            return (from d in db.DrugUnit
                    where d.DepotId == depotId
                        && !d.Shipped
                    select new QuantityDrugType()
                    {
                        DrugTypeName = d.DrugType.DrugTypeName,
                        DrugTypeId = d.DrugTypeId,
                        Quantity = 0
                    }).Distinct().ToList();
        }

        public Shipment Send(IEnumerable<QuantityDrugType> drugTypesInDepot, int depotId)
        {
            var drugUnits = (from d in db.DrugUnit
                             where d.DepotId == depotId
                                && !d.Shipped
                             select d).ToList();
            var shipment = GetDrugUnitsForSending(drugUnits, drugTypesInDepot);
            SaveChanges(drugUnits, shipment.ShippedList);

            return shipment;
        }

        private void SaveChanges(IEnumerable<DrugUnit> drugUnits, IEnumerable<String> shippedDrugUnitsId)
        {
            foreach(var id in shippedDrugUnitsId)
            {
                var x = drugUnits.First(d => d.DrugUnitId == id).Shipped = true;
            }
            db.SaveChanges();
        }

        private Shipment GetDrugUnitsForSending(IEnumerable<DrugUnit> drugUnits, IEnumerable<QuantityDrugType> drugTypesInDepot)
        {          
            Dictionary<int, List<DrugUnit>> drugUnitsByTypes = drugUnits.GroupBy(o => o.DrugTypeId)
                                                .ToDictionary(g => g.Key, g => g.ToList());

            var shippedDrugUnitsId = new List<string>();
            var unshippedDrugUnits = new Dictionary<string, int>();

            foreach (var d in drugTypesInDepot)
            {
                if (d.Quantity > 0)
                {
                    int shippedCount = d.Quantity;
                    int unshippedCount = 0;

                    if ((drugUnitsByTypes[d.DrugTypeId].Count - d.Quantity) < 0)
                    {
                        shippedCount = drugUnitsByTypes[d.DrugTypeId].Count;
                        unshippedCount = d.Quantity - drugUnitsByTypes[d.DrugTypeId].Count;
                        unshippedDrugUnits.Add(d.DrugTypeName, unshippedCount);
                    }

                    for (int i = 0; i < shippedCount; i++)
                    {
                        shippedDrugUnitsId.Add(drugUnitsByTypes[d.DrugTypeId][i].DrugUnitId);
                    }
                }
            }
            return new Shipment
            {
                ShippedList = shippedDrugUnitsId,
                UnshippedDictionary = unshippedDrugUnits
            };
        }

    }
}
