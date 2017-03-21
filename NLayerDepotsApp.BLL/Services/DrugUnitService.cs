using NLayerDepotsApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerDepotsApp.DAL.Interfaces;
using NLayerDepotsApp.BLL.DTO;
using NLayerDepotsApp.DAL.Entities;
using NLayerDepotsApp.DAL.Interfaces;
using AutoMapper;

namespace NLayerDepotsApp.BLL.Services
{
    public class DrugUnitService : IService
    {
        IUnitOfWork Database { get; set; }

        public DrugUnitService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<DrugUnitDTO> GetDrugUnits()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnit, DrugUnitDTO>()
                            .ForMember("DepotName", opt => opt.MapFrom(src => src.Depot.DepotName))
                            .ForMember("DrugTypeName", opt => opt.MapFrom(src => src.DrugType.DrugTypeName)));
            return Mapper.Map<List<DrugUnit>, List<DrugUnitDTO>>(Database.DrugUnits.GetAll().ToList());
        }
    }
}
