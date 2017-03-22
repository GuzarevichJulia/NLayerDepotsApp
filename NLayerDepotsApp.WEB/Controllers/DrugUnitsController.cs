using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerDepotsApp.BLL.Interfaces;
using NLayerDepotsApp.BLL.DTO;
using NLayerDepotsApp.WEB.Models;
using AutoMapper;
using NLayerDepotsApp.BLL.Infrastructure;

namespace NLayerDepotsApp.WEB.Controllers
{
    public class DrugUnitsController : Controller
    {
        IDrugUnitService drugUnitService;

        public DrugUnitsController(IDrugUnitService service)
        {
            drugUnitService = service;
        }

        public ActionResult Index()
        {
            IEnumerable<DrugUnitDTO> drugUnitDtos = drugUnitService.GetDrugUnits();
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitDTO, DrugUnitViewModel>());
            var drugUnits = Mapper.Map<IEnumerable<DrugUnitDTO>, List<DrugUnitViewModel>>(drugUnitDtos);
            return View(drugUnits);
        }

        public ActionResult EditDrugUnit(string id)
        {
            /*DrugUnitDTO drugUnitDto = drugUnitService.GetDrugUnit(id);
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitDTO, DrugUnitViewModel>());
            var drugUnit = Mapper.Map<DrugUnitDTO, DrugUnitViewModel>(drugUnitDto);*/
            var editingDrugUnit = new EditingDrugUnitViewModel
            {
                DepotsList = drugUnitService.GetDepotsList(),
                DrugUnitId = id
            };
            return View(editingDrugUnit);
        }
        
        [HttpPost]
        public ActionResult EditDrugUnit(DrugUnitViewModel drugUnit)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitViewModel, DrugUnitDTO>());
            var drugUnitDto = Mapper.Map<DrugUnitViewModel, DrugUnitDTO>(drugUnit);
            drugUnitService.Edit(drugUnitDto);
            return RedirectToAction("Index");
        }
    }
}