using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.AccessConst;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Enum;
using Domain.Models.ProjectTests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Math.EC.Rfc7748;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class ReportsController : BaseController
    {

        private IProjectService _projectService;
        private ICodeReviewService _codeReviewService;
        private ILoadAndSterssService _loadAndSterssService;
        private ICodeReviewDetailService _codeReviewDetailService;
        private ITestHeaderService _testHeaderService;
        private IDocReviewService _docReviewService;
        private IProjectVersionService _projectVersionService;

        public ReportsController(IProjectService projectService, ICodeReviewService codeReviewService, ILoadAndSterssService loadAndSterssService, ICodeReviewDetailService codeReviewDetailService, ITestHeaderService testHeaderService, IDocReviewService docReviewService, IProjectVersionService projectVersionService)
        {
            _projectService = projectService;
            _codeReviewService = codeReviewService;
            _loadAndSterssService = loadAndSterssService;
            _codeReviewDetailService = codeReviewDetailService;
            _testHeaderService = testHeaderService;
            _docReviewService = docReviewService;
            _projectVersionService = projectVersionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FunctionalReport()
        {

            SelectedSideBar(AccessConst.FunctionalReport);

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

            var AllReport = new AllReportInformationVM();

            AllReport.ProjectId = ProjectId;
            AllReport.VersionId = Version;

            AllReport.CodeReview = new CodeReviewVM();
            AllReport.CodeReview.CodeReviewDetailList = new List<CodeReviewDetailVM>();
            AllReport.LoadOrStrssTestsList = new CreateLoadOrStrssTest();

            //// بررسی کد

            if (ReportTypes.Contains("CodeReview"))
            {
                ViewBag.hasCode = true;

                AllReport.CodeReview.AccurateMatch = CodeReviewMatch(ProjectId, "Accurate", Version);
                AllReport.CodeReview.HighMatch = CodeReviewMatch(ProjectId, "High", Version);
                AllReport.CodeReview.NormalMatch = CodeReviewMatch(ProjectId, "Normal", Version);
                AllReport.CodeReview.PoorMatch = CodeReviewMatch(ProjectId, "Poor", Version);

                AllReport.CodeReview.PercentAccurate = CodeReviewMatchPercent(ProjectId, "Accurate", Version);
                AllReport.CodeReview.PercentHigh = CodeReviewMatchPercent(ProjectId, "High", Version);
                AllReport.CodeReview.PercentNormal = CodeReviewMatchPercent(ProjectId, "Normal", Version);
                AllReport.CodeReview.PercentPoor = CodeReviewMatchPercent(ProjectId, "Poor", Version);


                AllReport.CodeReview.CodeReviewDetailList =
                    _codeReviewDetailService.GetCodeReviewDetailByProjectIdAndVersionId(ProjectId, Version);



            }

            //// بررسی سند


            ViewBag.hasDoc = ReportTypes.Contains("DocReview");

            var TestHeader = _testHeaderService.GetTestListByProjectId(ProjectId, Version)
                .Where(x => x.EntityType == "DocReview").ToList();
            if (TestHeader.Any())
            {
                AllReport.DocReviewList = _docReviewService.GetDocReviewsByDocId(TestHeader.FirstOrDefault().Id);
            }

            /// تست بار و استرس

            ViewBag.HasLoad = ReportTypes.Contains("StressAndLoad");


            AllReport.LoadOrStrssTestsList = _loadAndSterssService.GetByProjectIdAndVersionId(ProjectId, Version);



            return PartialView("_ShowProjectInfo", AllReport);
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
            var ReportTypes = _testHeaderService.GetAllVertionTestListByProjectId(ProjectId).Select(x => x.EntityType).Distinct().ToArray();
            ViewBag.ProjectId = ProjectId;

            var model = new AggregateReportVM();
            
            ////// بررسی کد
            
            if (ReportTypes.Contains("CodeReview"))
            {
                ViewBag.hasCode = true;

                var versionList = _testHeaderService.GetAllVertionTestListByProjectId(ProjectId)
                    .Where(x => x.ProjectVersionId.HasValue && x.EntityType == "CodeReview")
                    .Select(x => x.ProjectVersionId.Value).Distinct().ToArray();

                model.CodeReviewVersions = _projectVersionService.GetAllVersionNames(versionList);

                model.CodeReviewVersionsList = new List<CodeReviewVersions>();

                model.CodeReviewVersionsList = GetAllCodeReviewVersion(versionList, ProjectId);

                var x = model.CodeReviewVersionsList.Select(x => x.AccurateMatch).ToArray();
                

            }


            //// بررسی سند

            ViewBag.hasDoc = ReportTypes.Contains("DocReview");

            var DocReviewsList = _testHeaderService.GetAllVertionTestListByProjectId(ProjectId)
                .Where(x => x.ProjectVersionId.HasValue && x.EntityType == "DocReview")
                .Select(x => x.ProjectVersionId.Value).Distinct().ToArray();
            if (DocReviewsList.Any())
            {
                model.DocReviewVersionsList = GetAllDocReviewsByDocIds(DocReviewsList,ProjectId);
            }

            ///// تست بار و استرس

            ViewBag.HasLoad = ReportTypes.Contains("StressAndLoad");


            model.CreateLoadOrStrssTests = _loadAndSterssService.GetAllVertionByProjectId(ProjectId);



            return PartialView("_ShowAllVersionProjectInfo",model);
        }


        private List<DocReviewVersions> GetAllDocReviewsByDocIds(int[] versionList, int projectId)
        {
            var result = new List<DocReviewVersions>();

            foreach (var VersionId in versionList)
            {
                var TestHeader = _testHeaderService.GetTestListByProjectId(projectId, VersionId).LastOrDefault(x => x.EntityType == "DocReview");

                var model = new DocReviewVersions();

                var DocReviewList = _docReviewService.GetDocReviewsByDocId(TestHeader.Id);

                model.Version = _projectVersionService.GetByPK(VersionId).Name;
                model.ActivityDiagram = DocReviewList.Where(x => x.DocReviewTitle == DocReviewTitle.ActivityDiagram)
                    .Select(x => x.DocReviewAnswer).FirstOrDefault();
                model.ActivityDescription = DocReviewList
                    .Where(x => x.DocReviewTitle == DocReviewTitle.ActivityDescription).Select(x => x.DocReviewAnswer)
                    .FirstOrDefault();
                model.ApplicationDiagram = DocReviewList
                    .Where(x => x.DocReviewTitle == DocReviewTitle.ApplicationDiagram).Select(x => x.DocReviewAnswer)
                    .FirstOrDefault();
                model.ClassDiagram = DocReviewList.Where(x => x.DocReviewTitle == DocReviewTitle.ClassDiagram)
                    .Select(x => x.DocReviewAnswer).FirstOrDefault();
                model.Modules = DocReviewList.Where(x => x.DocReviewTitle == DocReviewTitle.Modules)
                    .Select(x => x.DocReviewAnswer).FirstOrDefault();
                model.SequenceDiagram = DocReviewList.Where(x => x.DocReviewTitle == DocReviewTitle.SequenceDiagram)
                    .Select(x => x.DocReviewAnswer).FirstOrDefault();

                result.Add(model);
            }

            return result;

        }


        private List<CodeReviewVersions> GetAllCodeReviewVersion(int[] versionList, int projectId)
        {
            var result = new List<CodeReviewVersions>();
            foreach (var VersionId in versionList)
            {
                var TestHeader = _testHeaderService.GetTestListByProjectId(projectId, VersionId).LastOrDefault(x => x.EntityType == "CodeReview");

                var model = new CodeReviewVersions();
                
                model.AccurateMatch = CodeReviewMatch(projectId, "Accurate", VersionId);
                model.HighMatch = CodeReviewMatch(projectId, "High", VersionId);
                model.NormalMatch = CodeReviewMatch(projectId, "Normal", VersionId);
                model.PoorMatch = CodeReviewMatch(projectId, "Poor", VersionId);
                model.AllCountRow = model.AccurateMatch + model.HighMatch + model.NormalMatch + model.PoorMatch;


                model.PercentAccurateMatch = CodeReviewMatchPercent(projectId, "Accurate", VersionId);
                model.PercentHighMatch = CodeReviewMatchPercent(projectId, "High", VersionId);
                model.PercentNormalMatch = CodeReviewMatchPercent(projectId, "Normal", VersionId);
                model.PercentPoorMatch = CodeReviewMatchPercent(projectId, "Poor", VersionId);


                var codereview = _codeReviewService.GetCodeReviewsByHeaderId(TestHeader.Id);
                var CodeReviewDetail =
                    _codeReviewDetailService.GetCodeReviewDetailByTestHeaderId(codereview.Id);

                model.Readability = CodeReviewDetail.Where(x=>x.DetailType == CodeReviewDetailType.Readability).Sum(x=>x.Score);
                model.ObjectOriented = CodeReviewDetail.Where(x => x.DetailType == CodeReviewDetailType.ObjectOriented).Sum(x => x.Score);
                model.CodeSecurity = CodeReviewDetail.Where(x => x.DetailType == CodeReviewDetailType.CodeSecurity).Sum(x => x.Score);
                model.UseOfResources = CodeReviewDetail.Where(x => x.DetailType == CodeReviewDetailType.UseOfResources).Sum(x => x.Score);
                model.Complexity = CodeReviewDetail.Where(x => x.DetailType == CodeReviewDetailType.Complexity).Sum(x => x.Score);
                model.Warning = CodeReviewDetail.Where(x => x.DetailType == CodeReviewDetailType.Warning).Sum(x => x.Score);

                result.Add(model);
            }

            return result;
        }

    }
}