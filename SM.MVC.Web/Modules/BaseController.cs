using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.AccessConst;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace SM.MVC.Web.Modules
{
    public abstract class BaseController : Controller
    {

        protected void NotifyError(string msg = "Error")
        {
            Notify("Error", msg);
        }

        protected void NotifySuccess(string msg = "Success")
        {
            Notify("Success", msg);
        }

        protected void NotifyInfo(string msg = "Info")
        {
            Notify("Info", msg);
        }

        protected void NotifyWarning(string msg = "Warning")
        {
            Notify("Warning", msg);
        }

        protected void Notify(string msgType, string msg)
        {
            TempData[msgType] = msg;
        }

        protected void SelectedSideBar(string Access)
        {

            //var identity = HttpContext.User.Identity as ClaimsIdentity;

            //identity.RemoveClaim(identity.FindFirst("SelectedPage"));
            //identity.AddClaim(new Claim("SelectedPage", Access));

            HttpContext.Session.SetString("SelectedPage", Access);

        }
        
    }
}