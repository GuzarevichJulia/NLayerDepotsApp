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
    public class SQLDrugUnitRepository : SQLBaseRepository<DrugUnit>, IDrugUnitRepository
    {
        public SQLDrugUnitRepository(DrugsContext context) : base(context)
        {
            entity = db.DrugUnit;
        }

        public DrugUnit GetById(string id)
        {
            return entity.Find(id);
        }

        public void Delete(string id)
        {
            DrugUnit drugUnit = entity.Find(id);
            if (drugUnit != null)
            {
                entity.Remove(drugUnit);
            }
        }

        public IQueryable<DrugUnit> GetAvailableDrugUnitsFromDepot(int depotId)
        {
            return from d in entity
                   where d.DepotId == depotId
                   where d.Shipped == false
                   select d;
        }        
    }
}
