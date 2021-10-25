using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}