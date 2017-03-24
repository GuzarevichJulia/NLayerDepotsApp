using NLayerDepotsApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerDepotsApp.DAL.Interfaces;
using NLayerDepotsApp.BLL.DTO;
using NLayerDepotsApp.DAL.Entities;
using AutoMapper;
using System.Web.Mvc;

namespace NLayerDepotsApp.BLL.Services
{
    public class DrugUnitService : IDrugUnitService
    {
        IUnitOfWork Database { get; set; }

        public DrugUnitService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public SelectList GetDepotsList()
        {
            return new SelectList(Database.Depots.GetAll(), "DepotId", "DepotName");
        } 

        public void Edit(DrugUnitDTO drugUnitDto)
        {
            DrugUnit drugUnit = Database.DrugUnits.GetById(drugUnitDto.DrugUnitId);
            if (drugUnitDto.DepotId != 0)
            {
                drugUnit.DepotId = drugUnitDto.DepotId;
            }
            else
            {
                drugUnit.DepotId = null;
            }
            Database.Save();
        }

        public IEnumerable<DrugUnitDTO> GetDrugUnits(int skipCount, int? drugUnitCount)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnit, DrugUnitDTO>()
                            .ForMember("DepotName", opt => opt.MapFrom(src => src.Depot.DepotName))
                            .ForMember("DrugTypeName", opt => opt.MapFrom(src => src.DrugType.DrugTypeName)));
            if ((skipCount == 0) && (drugUnitCount == null))
            {
                return Mapper.Map<List<DrugUnit>, List<DrugUnitDTO>>(Database.DrugUnits.GetAll().ToList());
            }
            else
            {
                return Mapper.Map<List<DrugUnit>, List<DrugUnitDTO>>(Database.DrugUnits.GetDrugUnits(skipCount,(int)drugUnitCount).ToList());
            }
        }

        public int GetDrugUnitsCount()
        {
            return Database.DrugUnits.Count();
        }

        public DrugUnitDTO GetDrugUnit(string id)
        {
            var drugUnit = Database.DrugUnits.GetById(id);
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnit, DrugUnitDTO>());
            return Mapper.Map<DrugUnit, DrugUnitDTO>(drugUnit);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
