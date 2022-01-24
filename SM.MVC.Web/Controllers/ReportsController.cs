using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {

        private IProjectService _projectService;
        private ICodeReviewService _codeReviewService;
        private ITestHeaderService _testHeaderService;
        private IDocReviewService _docReviewService;

        public ReportsController(IProjectService projectService, ICodeReviewService codeReviewService, ITestHeaderService testHeaderService, IDocReviewService docReviewService)
        {
            _projectService = projectService;
            _codeReviewService = codeReviewService;
            _testHeaderService = testHeaderService;
            _docReviewService = docReviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FunctionalReport()
        {
            if (User != null)
            {
                ViewBag.Projects = new SelectList(
                    _projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims
                        .Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                    "ProjectName");

                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult ShowProjectInfo(int ProjectId, int Version)
        {
            var ReportTypes = _testHeaderService.GetTestListByProjectId(ProjectId, Version).Select(x => x.EntityType).Distinct().ToArray();
            ViewBag.ProjectId = ProjectId;

            //// بررسی کد

            if (ReportTypes.Contains("CodeReview"))
            {


                ViewBag.hasCode = ReportTypes.Contains("CodeReview");
                ViewBag.Accurate = CodeReviewMatch(ProjectId, "Accurate", Version);
                ViewBag.High = CodeReviewMatch(ProjectId, "High", Version);
                ViewBag.Normal = CodeReviewMatch(ProjectId, "Normal", Version);
                ViewBag.Poor = CodeReviewMatch(ProjectId, "Poor", Version);

                ViewBag.PercentAccurate = CodeReviewMatchPercent(ProjectId, "Accurate", Version);
                ViewBag.PercentHigh = CodeReviewMatchPercent(ProjectId, "High", Version);
                ViewBag.PercentNormal = CodeReviewMatchPercent(ProjectId, "Normal", Version);
                ViewBag.PercentPoor = CodeReviewMatchPercent(ProjectId, "Poor", Version);

            }

            //// بررسی سند


            ViewBag.hasDoc = ReportTypes.Contains("DocReview");

            var TestHeader = _testHeaderService.GetTestListByProjectId(ProjectId, Version)
                .Where(x => x.EntityType == "DocReview").ToList();
            var model = new List<DocReviewVM>();
            if (TestHeader.Any())
            {
                model = _docReviewService.GetDocReviewsByDocId(TestHeader.FirstOrDefault().Id);
            }

            /// تست بار و استرس

            ViewBag.HasLoad = ReportTypes.Contains("StressAndLoad");




            return PartialView("_ShowProjectInfo", model);
        }

        private int CodeReviewMatch(int ProjectId, string Type, int Version)
        {
            var CodeReview = _codeReviewService.GetByProjectId(ProjectId, Version);
            var result = 0;

            switch (Type)
            {
                case "Accurate":
                    result = CodeReview.AccurateMatch;
                    break;
                case "High":
                    result = CodeReview.HighMatch;
                    break;
                case "Normal":
                    result = CodeReview.NormalMatch;
                    break;
                case "Poor":
                    result = CodeReview.PoorMatch;
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;

        }

        private decimal CodeReviewMatchPercent(int ProjectId, string Type, int Version)
        {
            var CodeReview = _codeReviewService.GetByProjectId(ProjectId, Version);
            decimal result = 0;
            decimal x = 0;

            switch (Type)
            {
                case "Accurate":
                    x = Convert.ToDecimal(CodeReview.AccurateMatch + CodeReview.HighMatch + CodeReview.NormalMatch +
                                               CodeReview.PoorMatch);
                    result = (Convert.ToDecimal(Convert.ToDecimal(CodeReview.AccurateMatch) / x) * 100);

                    break;
                case "High":
                    x = Convert.ToDecimal(CodeReview.AccurateMatch + CodeReview.HighMatch +
                                              CodeReview.NormalMatch + CodeReview.PoorMatch);
                    result = (Convert.ToDecimal(Convert.ToDecimal(CodeReview.HighMatch) / x) * 100);
                    break;
                case "Normal":
                    x = Convert.ToDecimal(CodeReview.AccurateMatch + CodeReview.HighMatch +
                                              CodeReview.NormalMatch + CodeReview.PoorMatch);
                    result = (Convert.ToDecimal(Convert.ToDecimal(CodeReview.NormalMatch) / x) * 100);
                    break;
                case "Poor":
                    x = Convert.ToDecimal(CodeReview.AccurateMatch + CodeReview.HighMatch +
                                              CodeReview.NormalMatch + CodeReview.PoorMatch);
                    result = (Convert.ToDecimal(Convert.ToDecimal(CodeReview.PoorMatch) / x) * 100);
                    break;
                default:
                    result = 0;
                    break;
            }

            var round = Math.Round(result);

            return round;
        }

        public IActionResult ShowAllVersionProjectInfo(int ProjectId)
        {
            //var ReportTypes = _testHeaderService.GetTestListByProjectId(ProjectId, Version).Select(x => x.EntityType).Distinct().ToArray();
            //ViewBag.ProjectId = ProjectId;

            //ViewBag.hasCode = ReportTypes.Contains("CodeReview");
            //ViewBag.Accurate = CodeReviewMatch(ProjectId, "Accurate", Version);
            //ViewBag.High = CodeReviewMatch(ProjectId, "High", Version);
            //ViewBag.Normal = CodeReviewMatch(ProjectId, "Normal", Version);
            //ViewBag.Poor = CodeReviewMatch(ProjectId, "Poor", Version);

            //ViewBag.PercentAccurate = CodeReviewMatchPercent(ProjectId, "Accurate", Version);
            //ViewBag.PercentHigh = CodeReviewMatchPercent(ProjectId, "High", Version);
            //ViewBag.PercentNormal = CodeReviewMatchPercent(ProjectId, "Normal", Version);
            //ViewBag.PercentPoor = CodeReviewMatchPercent(ProjectId, "Poor", Version);

            return PartialView("_ShowAllVersionProjectInfo");
        }
    }
}