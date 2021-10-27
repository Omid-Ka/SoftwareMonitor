using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult Index()
        {
            var data = _usersService.GetAllUsers();
            return View(data);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        //public ActionResult GetAccountList()
        //{
            

        //    return Json(data);
        //}
    }
}