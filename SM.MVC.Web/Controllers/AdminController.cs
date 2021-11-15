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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}