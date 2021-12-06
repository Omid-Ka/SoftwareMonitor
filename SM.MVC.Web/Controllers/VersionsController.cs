using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class VersionsController : BaseController
    {

        private IProjectVersionService _projectVersionService;

        public VersionsController(IProjectVersionService projectVersionService)
        {
            _projectVersionService = projectVersionService;
        }

        public IActionResult Index()
        {
            var date = _projectVersionService.GetAllVertion();
            return View(date);
        }   


        public IActionResult CreateVersion(ProjectVersionDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
