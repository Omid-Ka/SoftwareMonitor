using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class AdminController : BaseController
    {

        //[Authorize]
        public IActionResult Index()
        {
            SelectedSideBar("");
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult PostChangePassword()
        {
            return null;
        }
    }
}