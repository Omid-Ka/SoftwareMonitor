using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}