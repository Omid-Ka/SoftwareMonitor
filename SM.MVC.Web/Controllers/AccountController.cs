﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Account;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IUsersService _usersService;
        private ILookupService _lookupService;

        public AccountController(IUsersService usersService, ILookupService lookupService)
        {
            _usersService = usersService;
            _lookupService = lookupService;
        }

        public IActionResult Index()
        {
            var data = _usersService.GetAllUsers();
            return View(data);
        }

        public IActionResult CreateUser()
        {
            ViewBag.Gender = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Gender), "Id",
                "Description","");
            ViewBag.Post = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Post), "Id",
                "Description","");
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Users model)
        {
            ViewBag.Gender = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Gender), "Id",
                "Description", "");
            ViewBag.Post = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Post), "Id",
                "Description", "");

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateUser");
            }

            bool HasUser = _usersService.HasUserWithUserName(model.UserName);
            if (HasUser)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateUser");
            }
            HasUser = _usersService.HasUserWithNationalcode(model.NationalCode);
            if (HasUser)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateUser");
            }
            HasUser = _usersService.HasUserWithPersonnelCode(model.PersonnelCode);
            if (HasUser)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateUser");
            }

            _usersService.AddUser(model,User);

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

        public IActionResult DeleteUser(int UserId)
        {
            _usersService.DeleteUser(UserId,User);

            var data = _usersService.GetAllUsers();

            return PartialView("_UserGrid",data);
        }


        public IActionResult EditUser(int UserId)
        {
            ViewBag.Gender = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Gender), "Id",
                "Description", "");
            ViewBag.Post = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Post), "Id",
                "Description", "");

            var model = _usersService.GetUserById(UserId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(Users model)
        {
            ViewBag.Gender = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Gender), "Id",
                "Description", "");
            ViewBag.Post = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Post), "Id",
                "Description", "");

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateUser");
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

            _usersService.EditUser(model, User);

            NotifyError("با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }

        public IActionResult ShowModal(int UserId)
        {
            var Model = new AccountSummary();


            return PartialView("_UserDetail",Model);
        }

    }
}