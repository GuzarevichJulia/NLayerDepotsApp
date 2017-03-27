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

        public ActionResult DisplayAll()
        {
            IEnumerable<DrugUnitDTO> drugUnitsDto = drugUnitService.GetDrugUnits();
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitDTO, DrugUnitViewModel>());
            var drugUnits = Mapper.Map<IEnumerable<DrugUnitDTO>, List<DrugUnitViewModel>>(drugUnitsDto);
            return View(drugUnits);
        }

        [HttpGet]
        public ActionResult Display(int page = 1)
        {
            int pageSize = 15;
            IEnumerable<DrugUnitDTO> drugUnitsDto = drugUnitService.GetDrugUnits((page - 1) * pageSize, pageSize);
            PageInfoViewModel pageInfo = new PageInfoViewModel
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = drugUnitService.GetDrugUnitsCount()
            };

            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitDTO, DrugUnitViewModel>());
            var drugUnits = Mapper.Map<IEnumerable<DrugUnitDTO>, List<DrugUnitViewModel>>(drugUnitsDto);
            DrugUnitIndexViewModel drugUnitsIndex = new DrugUnitIndexViewModel
            {
                PageInfo = pageInfo,
                DrugUnits = drugUnits
            };
            var defEl = new SelectListItem { Text = "Not Selected", Value = "0" };
            List<SelectListItem> newList = drugUnitService.GetDepotsList().ToList();
            newList.Insert(0, defEl);
            drugUnitsIndex.DepotsList = new SelectList(newList, "Value", "Text");

            return View(drugUnitsIndex);
        }
        
          
        public ActionResult Edit(int? id, string drugUnitId="10")
        {
            drugUnitService.Edit((int)id, drugUnitId);
            var res = 1;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditDrugUnit(string id)
        {
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
            drugUnitService.Edit((int)drugUnitDto.DepotId, drugUnitDto.DrugUnitId);
            return RedirectToAction("Display");
        }
    }
}