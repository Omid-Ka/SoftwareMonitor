using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class BasicInformationController : BaseController
    {
        private ILookupService _lookupService;

        public BasicInformationController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public IActionResult Index()
        {
            var data = _lookupService.GetAll();
            return View(data);
        }

        public IActionResult CreateInformation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInformation(Lookup model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateInformation");
            }

            bool HasInformation = _lookupService.HaslookupWithDescription(model.Description , model.Category);
            if (HasInformation)
            {
                NotifyError("اطلاعات تکراری می باشد");
                return View("CreateInformation");
            }


            _lookupService.AddLookup(model, User);

            NotifyError("با موفقیت ثبت شد");
            return RedirectToAction("Index");
        }

        //public IActionResult CreateUserTest()
        //{
        //    return View();
        //}
        //public ActionResult GetAccountList()
        //{


        //    return Json(data);
        //}

        public IActionResult DeleteLookup(int LookupId)
        {
            _lookupService.DeleteLookup(LookupId, User);

            var data = _lookupService.GetAll();

            return PartialView("_lookupGrid", data);
        }


        public IActionResult EditLookup(int LookupId)
        {
            var model = _lookupService.GetByLookupId(LookupId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditLookup(Lookup model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("EditLookup");
            }

            //bool HasUser = _usersService.HasUserWithUserName(model.UserName);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithNationalcode(model.NationalCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithPersonnelCode(model.PersonnelCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}

            _lookupService.Editlookup(model, User);

            NotifyError("با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }



    }
}