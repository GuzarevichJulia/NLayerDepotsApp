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
    }
}