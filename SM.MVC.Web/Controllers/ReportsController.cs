using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FunctionalReport()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}