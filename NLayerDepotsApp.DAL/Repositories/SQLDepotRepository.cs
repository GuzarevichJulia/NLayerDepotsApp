using NLayerDepotsApp.DAL.EF;
using NLayerDepotsApp.DAL.Entities;
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
            entity = db.Depot;
        }

        public Depot GetById(int id)
        {
            return entity.Find(id);
        }

        public void Delete(int id)
        {
            Depot depot = entity.Find(id);
            if (depot != null)
            {
                entity.Remove(depot);
            }
        }

        public IQueryable<WeightInfo> GetTypesWeight()
        {
            return from du in db.DrugUnit
                   where du.DepotId != null
                   group new { du.Depot, du.DrugType, du } by new
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
                       Count = g.Count(p => p.du.DrugUnitId != null)
                   };
        }

        public IQueryable<DepotsInfo> GetDrugUnitsFromDepots()
        {
            return from depot in entity
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
                    where d.Shipped == false
                    select new QuantityDrugType()
                    {
                        DrugTypeName = d.DrugType.DrugTypeName,
                        DrugTypeId = d.DrugTypeId,
                        Quantity = 0
                    }).Distinct().ToList();
        }

        /*public Shipment Send(DrugTypesInDepot drugTypesInDepot)
        {
            var drugUnits = (from d in entity
                             where d.DepotId == drugTypesInDepot.DepotId
                             where d.Shipped == false
                             select d).ToList();


            var shippedDrugUnitsId = new List<string>();
            var unshippedDrugUnits = new Dictionary<string, int>();

            foreach (var d in drugTypesInDepot.AvailableDrugTypes)
            {
                var drugUnitWithType = (from t in drugUnits
                                        where t.DrugTypeId == d.DrugTypeId
                                        select t).ToList();

                int shippedCount;
                int unshippedCount = 0;
                if (d.Quantity < 0)
                {
                    shippedCount = 0;
                }
                if ((drugUnitWithType.Count - d.Quantity) < 0)
                {
                    shippedCount = drugUnitWithType.Count;
                    unshippedCount = d.Quantity - drugUnitWithType.Count;
                    unshippedDrugUnits.Add(d.DrugTypeName, unshippedCount);
                }
                else
                {
                    shippedCount = d.Quantity;
                }

                for (int i = 0; i < shippedCount; i++)
                {
                    drugUnitWithType[i].Shipped = true;
                    shippedDrugUnitsId.Add(drugUnitWithType[i].DrugUnitId);
                }
            }
            db.SaveChanges();

            return new Shipment
            {
                Shipped = shippedDrugUnitsId,
                Unshipped = unshippedDrugUnits
            };
        }*/

    }
}
