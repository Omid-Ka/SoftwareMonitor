using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SM.MVC.Web.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            ViewBag.Roles = UserClaimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value)
                .ToArray();


            //ViewBag.SelectedItem = UserClaimsPrincipal.Claims.Where(x => x.Type == "SelectedPage").Select(x => x.Value)
            //    .FirstOrDefault();

            ViewBag.SelectedItem = HttpContext.Session.GetString("SelectedPage") ?? "";

            return View("SIdeBarComponent");
        }

    }
}
