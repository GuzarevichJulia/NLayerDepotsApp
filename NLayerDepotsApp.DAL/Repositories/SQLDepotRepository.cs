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

    }
}
