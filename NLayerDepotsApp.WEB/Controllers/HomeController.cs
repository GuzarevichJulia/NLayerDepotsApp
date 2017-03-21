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
    public class HomeController : Controller
    {
        IService service;

        public HomeController(IService serv)
        {
            service = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<DrugUnitDTO> drugUnitDtos = service.GetDrugUnits();
            Mapper.Initialize(cfg => cfg.CreateMap<DrugUnitDTO, DrugUnitViewModel>());
            var drugUnits = Mapper.Map<IEnumerable<DrugUnitDTO>, List<DrugUnitViewModel>>(drugUnitDtos);
            return View(drugUnits);
        }
        
    }
}