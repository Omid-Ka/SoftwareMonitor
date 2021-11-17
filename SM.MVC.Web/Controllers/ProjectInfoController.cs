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
        private IDocReviewService _docReviewService;
        private ICodeReviewService _codeReviewService;
        private ICodeReviewDetailService _codeReviewDetailService;

        public ProjectInfoController(ILookupService lookupService, IProjectService projectService, ITestHeaderService testHeaderService, IDocReviewService docReviewService, ICodeReviewService codeReviewService, ICodeReviewDetailService codeReviewDetailService)
        {
            _lookupService = lookupService;
            _projectService = projectService;
            _testHeaderService = testHeaderService;
            _docReviewService = docReviewService;
            _codeReviewService = codeReviewService;
            _codeReviewDetailService = codeReviewDetailService;
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
                "Description");

            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");


            var result = new List<DocReviewVM>();
            foreach (DocReviewTitle type in Enum.GetValues(typeof(DocReviewTitle)))
            {
                result.Add(new DocReviewVM()
                {
                    DocReviewTitle = type
                });
            }

            var model = new CreateTestVM();
            model.DocReviewList = result;


            return View(model);
        }

        [HttpPost]
        public IActionResult PostCreateDocReview(GetTestHeaderVM Head, CreateTestVM model)
        {
            if (Head.ProjectId <= 0)
            {
                return Json(new { succeed = false, Message = "پروژه انتخاب نشده است" });
            }
            if (Head.TitleId <= 0)
            {
                return Json(new { succeed = false, Message = "عنوان تست انتخاب نشده است" });
            }
            if ((int)Head.TestType <= 0)
            {
                return Json(new { succeed = false, Message = "نوع تست مشخص نمی باشد" });
            }

            var TestHeader = new TestHeader();

            TestHeader.ProjectId = Head.ProjectId;
            TestHeader.TitleId = Head.TitleId;
            TestHeader.TestType = Head.TestType;
            TestHeader.EntityType = "DocReview";

            _testHeaderService.AddHeader(TestHeader, User);


            foreach (var item in model.DocReviewList)
            {
                var detail = new DocReview()
                {
                    DocReviewAnswer = item.DocReviewAnswer,
                    DocReviewTitle = item.DocReviewTitle,
                    Description = item.Description,
                    TestHeaderId = TestHeader.Id
                };

                _docReviewService.AdddocReview(detail, User);

            }

            return Json(new { succeed = true, Message = "با موفقیت ثبت شد" });

        }


        public IActionResult DeleteDoc(int DocId)
        {
            _testHeaderService.DeleteDoc(DocId, User);
            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 15 /*Document Review*/);

            return PartialView("_DocReviewGrid", data);

        }

        public IActionResult EditDoc(int DocId)
        {
            var result = _docReviewService.GetDocReviewsByDocId(DocId);
            var Head = _testHeaderService.GetByPk(DocId);

            var model = new CreateTestVM();
            model.DocReviewList = result;
            model.ProjectId = Head.ProjectId;
            model.Id = DocId;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditDoc(CreateTestVM model)
        {
            foreach (var item in model.DocReviewList)
            {
                _docReviewService.UpdatedocReview(new DocReview()
                {
                    Id = item.Id,
                    Description = item.Description,
                    DocReviewAnswer = item.DocReviewAnswer
                }, User);

            }

            NotifyError("با موفقیت ویرایش شد");
            return RedirectToAction("DocReview");
        }

        public IActionResult ShowDocModal(int DocId)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region CodeReview

        public IActionResult CodeReview()
        {
            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 15 /*Document Review*/);

            return View(data);
        }

        public IActionResult CreateCodeReview()
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");


            var model = new CreateCodeReviewVM();
            

            var result = new List<CodeReviewDetailVM>();
            foreach (CodeReviewDetailType type in Enum.GetValues(typeof(CodeReviewDetailType)))
            {
                var Lookup = _lookupService.GetAllByCategoryAndReference(type , LookupCategory.Indicator);
                foreach (var item in Lookup)
                {
                    result.Add(new CodeReviewDetailVM()
                    {
                        DetailType = type,
                        IndicatorId = item.Id,
                        IndicatorDesc = item.Description
                    });
                }
            }


            model.CodeReviewDetailList = result;
            
            return View(model);
        }


        [HttpPost]
        public IActionResult PostCreateCodeReview(CodeReviewVM Head, CreateCodeReviewVM model)
        {
            if (Head.ProjectId <= 0)
            {
                return Json(new { succeed = false, Message = "پروژه انتخاب نشده است" });
            }

            var TestHeader = new TestHeader();

            TestHeader.ProjectId = Head.ProjectId;
            TestHeader.TitleId = 16;
            TestHeader.TestType = TestType.Finctional;
            TestHeader.EntityType = "CodeReview";

            _testHeaderService.AddHeader(TestHeader, User);


            var CodeReview = new CodeReview()
            {
                AccurateMatch = Head.AccurateMatch,
                AllCountRow = Head.AllCountRow,
                HighMatch = Head.HighMatch,
                MatchGroups = Head.MatchGroups,
                NormalMatch = Head.NormalMatch,
                PoorMatch = Head.PoorMatch,
                TestHeaderId = TestHeader.Id,
                Offers = Head.Offers
            };

            _codeReviewService.AddCodeReview(CodeReview, User);


            foreach (var item in model.CodeReviewDetailList)
            {
                var Detail = new CodeReviewDetail()
                {
                    CodeReviewId = CodeReview.Id,
                    Description = item.Description,
                    DetailType = item.DetailType,
                    IndicatorId = item.IndicatorId,
                    Score = item.Score
                };

                _codeReviewDetailService.AddCodeReviewDetail(Detail, User);

            }






            return Json(new { succeed = true, Message = "با موفقیت ثبت شد" });

        }


        #endregion

        public IActionResult LoadAndStress()
        {
            return View();
        }
    }
}
