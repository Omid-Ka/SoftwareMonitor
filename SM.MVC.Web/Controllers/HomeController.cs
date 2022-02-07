using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Enum;
using EmailService;
using EmailService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SM.MVC.Web.Models;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IUserLogService _userLogService;
        private IUsersService _usersService;
        private IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IUserLogService userLogService, IUsersService usersService, IEmailSender emailSender)
        {
            _logger = logger;
            _userLogService = userLogService;
            _usersService = usersService;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Forgot(ForgotPasswordVM Model, IFormCollection form)
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
                return View("ForgotPassword");
            }
            if (ModelState.IsValid)
            {

                var ExistsEmail = _usersService.ExistsEmail(Model.Email);

                if (ExistsEmail)
                {
                    var rand = new Random();
                    var NewPassword = rand.Next(111111111, 999999999);

                    var CurrentUser = _usersService.GetUserByEmail(Model.Email);

                    CurrentUser.Password =  BCrypt.Net.BCrypt.HashPassword(NewPassword.ToString());

                    _usersService.UpdateUserPassword(CurrentUser);

                    var Content = string.Format("باسلام و احترام /n " +
                                                "کلمه عبور شما \n" +
                                                "{0} \n" +
                                                " می باشد.", NewPassword);

                    var message = new Message(new string[] { Model.Email }, "بازیابی کلمه عبور", Content);

                    _emailSender.SendEmail(message);

                    NotifySuccess("کلمه عبور جایگزین برای شما ارسال گردید.");
                    return RedirectToAction("Index", "Login");

                }
                else
                {
                    NotifyError("ایمیل در سامانه موجود نمی باشد");
                    return View("ForgotPassword");
                }
            }

            NotifyError("ایمیل را به درستی وارد نمایید");
            return View("ForgotPassword");
        }

        //public IActionResult SelectedLink(string Access)
        //{
            
        //}
    }
}
