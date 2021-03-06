﻿using NLayerDepotsApp.DAL.EF;
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
            dbSet = db.DrugUnit;
        }      

        public IQueryable<DrugUnit> GetDrugUnits(int skipCount, int count)
        {
            return dbSet.OrderBy(d => d.DrugUnitId).Skip(skipCount).Take(count);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public IQueryable<DrugUnit> GetAvailableDrugUnitsFromDepot(int depotId)
        {
            return from d in dbSet
                   where d.DepotId == depotId
                      && d.Shipped == false
                   select d;
        }        
    }
}
