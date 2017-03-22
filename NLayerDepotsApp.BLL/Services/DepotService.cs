using AutoMapper;
using NLayerDepotsApp.BLL.DTO;
using NLayerDepotsApp.BLL.Interfaces;
using NLayerDepotsApp.DAL.Entities;
using NLayerDepotsApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.BLL.Services
{
    public class DepotService : IDepotService
    {
        IUnitOfWork Database { get; set; }

        public DepotService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<DepotDTO> GetDepots()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Depot, DepotDTO>());
            return Mapper.Map<List<Depot>, List<DepotDTO>>(Database.Depots.GetAll().ToList());
        }

        public DepotDTO GetDepot(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Depot, DepotDTO>());
            return Mapper.Map<Depot, DepotDTO>(Database.Depots.GetById(id));
        }

        public IEnumerable<DepotsInfoDTO> GetDepotsInfo()
        {
            var depotsInfo = Database.Depots.GetDrugUnitsFromDepots().ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<DepotsInfo, DepotsInfoDTO>());
            return Mapper.Map<List<DepotsInfo>, List<DepotsInfoDTO>>(depotsInfo);
        }

        public IEnumerable<WeightInfoDTO> GetWeightInfo()
        {
            var weightInfo = Database.Depots.GetTypesWeight().ToList();

            double scale = 2.2;
            foreach(var item in weightInfo)
            {
                item.TotalWeight = item.Count * item.DrugTypeWeight / scale;
            }

            Mapper.Initialize(cfg => cfg.CreateMap<WeightInfo, WeightInfoDTO>());
            return Mapper.Map<List<WeightInfo>, List<WeightInfoDTO>>(weightInfo);
        }

        public IEnumerable<QuantityDrugTypeDTO> GetDrugTypesInDepot(int? id)
        {
            var drugTypesInDepot = Database.Depots.GetAvailableDrugTypesInDepot(id);
            Mapper.Initialize(cfg => cfg.CreateMap<QuantityDrugType, QuantityDrugTypeDTO>());
            return Mapper.Map<IEnumerable<QuantityDrugType>, List<QuantityDrugTypeDTO>>(drugTypesInDepot);
        }
    }
}
