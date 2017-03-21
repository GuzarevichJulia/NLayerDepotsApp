using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDrugUnitRepository DrugUnits { get; }
        IDepotRepository Depots { get; }
        void Save();
    }
}
