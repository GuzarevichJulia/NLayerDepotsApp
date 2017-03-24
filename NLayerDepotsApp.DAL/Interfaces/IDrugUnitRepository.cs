using NLayerDepotsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Interfaces
{
    public interface IDrugUnitRepository
    {
        IQueryable<DrugUnit> GetAll();
        IQueryable<DrugUnit> GetDrugUnits(int skipCount, int count);
        int Count();
        DrugUnit GetById(object id);
        void Create(DrugUnit item);
        void Update(DrugUnit item);
        void Delete(object id);
    }
}
