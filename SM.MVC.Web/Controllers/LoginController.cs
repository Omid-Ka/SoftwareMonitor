﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Account;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class LoginController : BaseController
    {

        private IUsersService _usersService;
        private IUserLogService _userLogService;

        public LoginController(IUsersService usersService, IUserLogService userLogService)
        {
            _usersService = usersService;
            _userLogService = userLogService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
       

        [HttpPost]
        public ActionResult Login(LoginVM model , IFormCollection form)
        {
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "6LfxrN0cAAAAAGWL3Li9D7wz6lEj3zp2dsterGJT"; // change this
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            if (!captChaesponse.Success)
            {
                ViewBag.Message = "لطفاً reCAPTCHA را تأیید کنید";
                return View("Index");
            }

            // go ahead and write code to validate username password against database


            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ورود به سامانه");
                return View("Index");
            }


            //var hasPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "MD5");

            Users UserModel = _usersService.GetUserForLogin(model.UserName, model.Password);

            if (UserModel == null)
            {
                NotifyError("کاربری یافت نشد");
                return View("Index");
            }

            var IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,UserModel.Id.ToString()),
                new Claim(ClaimTypes.Name,UserModel.Name.ToString()+" " + UserModel.Family.ToString()),
                new Claim(ClaimTypes.Email,UserModel.Email.ToString()),
                new Claim("IpAddress",IpAddress),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            var res = HttpContext.SignInAsync(principal, properties);

            _userLogService.AddEnterUserLog(UserModel.Id, IpAddress, UserLogType.Enter);

            return RedirectToAction("Index","Admin");
        }


        public IActionResult Logout()
        {
            _userLogService.AddUserLog(User,  UserLogType.Exit);
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index");
        }


    }
}