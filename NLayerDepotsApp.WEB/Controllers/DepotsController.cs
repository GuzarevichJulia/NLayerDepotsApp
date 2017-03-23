using AutoMapper;
using NLayerDepotsApp.BLL.DTO;
using NLayerDepotsApp.BLL.Interfaces;
using NLayerDepotsApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerDepotsApp.WEB.Controllers
{
    public class DepotsController : Controller
    {
        IDepotService depotService;

        public DepotsController(IDepotService service)
        {
            depotService = service;
        }

        public ActionResult WeightInfo()
        {
            var weightInfoDto = depotService.GetWeightInfo();
            Mapper.Initialize(cfg => cfg.CreateMap<WeightInfoDTO, WeightInfoViewModel>());
            var weightInfo = Mapper.Map<IEnumerable<WeightInfoDTO>, List<WeightInfoViewModel>>(weightInfoDto);
            return View(weightInfo);
        }

        public ActionResult DepotsInfo()
        {
            var depotsInfoDto = depotService.GetDepotsInfo();
            Mapper.Initialize(cfg => cfg.CreateMap<DepotsInfoDTO, DepotsInfoViewModel>());
            var depotsInfo = Mapper.Map<IEnumerable<DepotsInfoDTO>,List<DepotsInfoViewModel>>(depotsInfoDto);
            return View(depotsInfo);
        }

        public ActionResult Select()
        {
            IEnumerable<DepotDTO> depotsDto = depotService.GetDepots();
            Mapper.Initialize(cfg => cfg.CreateMap<DepotDTO, DepotViewModel>());
            var depots = Mapper.Map<IEnumerable<DepotDTO>, List<DepotViewModel>>(depotsDto);
            return View(depots);
        }

        [HttpGet]
        public ActionResult Send(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            var availableDrugTypesDto = depotService.GetDrugTypesInDepot(id);
            Mapper.Initialize(cfg => cfg.CreateMap<QuantityDrugTypeDTO, QuantityDrugTypeViewModel>());
            var availableDrugTypes = Mapper.Map<IEnumerable<QuantityDrugTypeDTO>, List<QuantityDrugTypeViewModel>>(availableDrugTypesDto);
            return View(new DrugTypesInDepotViewModel
                        {
                            DepotId = (int)id,
                            AvailableDrugTypes = availableDrugTypes
                         });
        }

        [HttpPost]
        public ActionResult Send(DrugTypesInDepotViewModel drugTypesInDepot)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<QuantityDrugTypeViewModel, QuantityDrugTypeDTO>());
            var drugTypesDto = Mapper.Map<IEnumerable<QuantityDrugTypeViewModel>, List<QuantityDrugTypeDTO>>(drugTypesInDepot.AvailableDrugTypes);
            var shimpentDto = depotService.SendDrugUnits(drugTypesDto, drugTypesInDepot.DepotId);
            Mapper.Initialize(cfg => cfg.CreateMap<ShipmentDTO, ShipmentViewModel>());
            var shipment = Mapper.Map<ShipmentDTO, ShipmentViewModel>(shimpentDto);
            return View("Shipment", shipment);
        }
    }
}