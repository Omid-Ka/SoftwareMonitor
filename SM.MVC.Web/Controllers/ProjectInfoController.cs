using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class ProjectInfoController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DocReview()
        {
            return View();
        }


        public IActionResult CodeReview()
        {
            return View();
        }


        public IActionResult LoadAndStress()
        {
            return View();
        }
    }
}
