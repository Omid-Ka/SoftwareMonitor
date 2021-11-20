using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SM.MVC.Web.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            ViewBag.Roles = UserClaimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value)
                .ToArray();

            return View("SIdeBarComponent");
        }

    }
}
