using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Enum;
using Domain.Models.ProjectTests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class ProjectInfoController : BaseController
    {
        private ILookupService _lookupService;
        private IProjectService _projectService;
        private ITestHeaderService _testHeaderService;

        public ProjectInfoController(ILookupService lookupService, IProjectService projectService, ITestHeaderService testHeaderService)
        {
            _lookupService = lookupService;
            _projectService = projectService;
            _testHeaderService = testHeaderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region DocReview

        
        public IActionResult DocReview()
        {
            
            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 15 /*Document Review*/);

            return View(data);
        }

        public IActionResult CreateDocReview()
        {
            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id",
                "Description", "");

            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName", "");


            var result = new List<DocReview>();
            foreach (DocReviewTitle type in Enum.GetValues(typeof(DocReviewTitle)))
            {
                result.Add(new DocReview()
                {
                    DocReviewTitle = type
                });
            }

            var model = new TestHeaderVM();
            model.DocReviewList = result;


            return View(model);
        }


        #endregion

        public IActionResult CodeReview()
        {
            return View();
        }


        public IActionResult LoadAndStress()
        {
            return View();
        }
    }
}
