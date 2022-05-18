using System;
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
        private IUserAccessService _userAccessService;
        private IAccessService _accessService;

        public LoginController(IUsersService usersService, IUserLogService userLogService, IUserAccessService userAccessService, IAccessService accessService)
        {
            _usersService = usersService;
            _userLogService = userLogService;
            _userAccessService = userAccessService;
            _accessService = accessService;
        }

        public IActionResult Index()
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                if (_usersService.IsDisable(User))
                {
                    return RedirectToAction("Logout", "Login");
                }
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
            //string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            //string secretKey = "6LfxrN0cAAAAAGWL3Li9D7wz6lEj3zp2dsterGJT"; // change this
            //string gRecaptchaResponse = form["g-recaptcha-response"];

            //var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            //// send post data
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            //request.Method = "POST";
            //request.ContentLength = postData.Length;
            //request.ContentType = "application/x-www-form-urlencoded";

            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    streamWriter.Write(postData);
            //}

            //// receive the response now
            //string result = string.Empty;
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    using (var reader = new StreamReader(response.GetResponseStream()))
            //    {
            //        result = reader.ReadToEnd();
            //    }
            //}

            //// validate the response from Google reCaptcha
            //var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            //if (!captChaesponse.Success)
            //{
            //    ViewBag.Message = "لطفاً reCAPTCHA را تأیید کنید";
            //    return View("Index");
            //}

            // go ahead and write code to validate username password against database


            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ورود به سامانه");
                return View("Index");
            }


            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            Users UserModel = _usersService.GetUserForLogin(model.UserName);

            if (UserModel == null || !BCrypt.Net.BCrypt.Verify(model.Password, UserModel.Password))
            {
                NotifyError("کاربری یافت نشد");
                return View("Index");
            }



            var AccessIds = _userAccessService.GetAllByUserId(UserModel.Id).Select(x => x.AccessId).ToArray();
            var Roles = _accessService.GetAllByIds(AccessIds);

            var IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,UserModel.Id.ToString()),
                new Claim(ClaimTypes.Name,UserModel.Name.ToString()+" " + UserModel.Family.ToString()),
                new Claim(ClaimTypes.Email,UserModel.Email.ToString()),
                new Claim("SelectedPage","داشبورد"),
                new Claim("IpAddress",IpAddress),
            };

            claims.AddRange(Roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            var res = HttpContext.SignInAsync(principal, properties);

            _userLogService.AddEnterUserLog(UserModel.Id, IpAddress, UserLogType.Enter);

            NotifySuccess(UserModel.Name +" "+ UserModel.Family + "  عزیز خوش آمدید ");
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