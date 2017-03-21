using NLayerDepotsApp.DAL.EF;
using NLayerDepotsApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DrugsContext db;
        private SQLDrugUnitRepository drugUnitRepository;
        private SQLDepotRepository depotRepository;

        public EFUnitOfWork()
        {
            db = new DrugsContext();
        }

        public IDrugUnitRepository DrugUnits
        {
            get
            {
                if (drugUnitRepository == null)
                {
                    drugUnitRepository = new SQLDrugUnitRepository(db);
                }
                return drugUnitRepository;
            }
        }

        public IDepotRepository Depots
        {
            get
            {
                if (depotRepository == null)
                {
                    depotRepository = new SQLDepotRepository(db);
                }
                return depotRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
