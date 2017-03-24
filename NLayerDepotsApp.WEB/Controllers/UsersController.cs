using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerDepotsApp.WEB.Models;

namespace NLayerDepotsApp.WEB.Controllers
{
    public class UsersController : Controller
    {
        List<UserViewModel> Users { get; set; }
        
        public UsersController()
        {
            Users = new List<UserViewModel>();
            Users.Add(new UserViewModel { UserId = 1, Email = "1@mail.ru", Password = "p1", Phone = "111", UserName = "first" });
            Users.Add(new UserViewModel { UserId = 2, Email = "2@mail.ru", Password = "p2", Phone = "222", UserName = "second" });
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserViewModel user)
        {
            ViewBag.Result = "Incorrect input data.";
            if (ModelState.IsValid)
            {
                if (!IsExist(user.UserName))
                {
                    Users.Add(user);
                    ViewBag.Result = "User was regestered succssfull.";
                }
                else
                {
                    ViewBag.Result = "User can't be registered. Such user already exists.";
                }
            }
            return View("Result");
        }

        private bool IsExist(string name)
        {
            return Users.Any(x => x.UserName == name);
        }
    }
}