using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.AccessConst;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Enum;
using Domain.Models.Projects;
using Domain.Models.ProjectTests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private ILoadAndSterssService _loadAndSterssService;
        private IProjectVersionService _projectVersionService;
        private IProjectCommentService _projectCommentService;
        private INotificationService _notificationService;

        public ProjectInfoController(ILookupService lookupService, IProjectService projectService, ITestHeaderService testHeaderService, IDocReviewService docReviewService, ICodeReviewService codeReviewService, ICodeReviewDetailService codeReviewDetailService, ILoadAndSterssService loadAndSterssService, IProjectVersionService projectVersionService, IProjectCommentService projectCommentService, INotificationService notificationService)
        {
            _lookupService = lookupService;
            _projectService = projectService;
            _testHeaderService = testHeaderService;
            _docReviewService = docReviewService;
            _codeReviewService = codeReviewService;
            _codeReviewDetailService = codeReviewDetailService;
            _loadAndSterssService = loadAndSterssService;
            _projectVersionService = projectVersionService;
            _projectCommentService = projectCommentService;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region DocReview


        public IActionResult DocReview()
        {

            SelectedSideBar(AccessConst.AddDocReview);

            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 15 /*Document Review*/);

            return View(data);
        }

        public IActionResult CreateDocReview()
        {
            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id",
                "Description");

            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");

            ViewBag.Version = new SelectList(new List<ProjectVersion>());


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

            if (Head.VersionId <= 0)
            {
                return Json(new { succeed = false, Message = "نسخه پروژه مشخص نمی باشد" });
            }

            if (!_projectVersionService.VersionHasValid(Head.ProjectId , Head.VersionId))
            {
                return Json(new { succeed = false, Message = "نسخه پروژه معتبر نمی باشد" });
            }

            var TestHeader = new TestHeader();

            TestHeader.ProjectId = Head.ProjectId;
            TestHeader.TitleId = Head.TitleId;
            TestHeader.TestType = Head.TestType;
            TestHeader.EntityType = "DocReview";
            TestHeader.ProjectVersionId = Head.VersionId;

            _testHeaderService.AddHeader(TestHeader, User);

            _notificationService.AddNotification(Head.VersionId, User);

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


            AddCommentOnProject(Head.ProjectId, Head.VersionId, Head.ExpertComment, TypeOfCommand.DocReview);

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

            NotifySuccess("با موفقیت ویرایش شد");
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

            SelectedSideBar(AccessConst.AddCodeReview);

            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 16 /*Document Review*/);

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


            if (Head.VersionId <= 0)
            {
                return Json(new { succeed = false, Message = "نسخه پروژه مشخص نمی باشد" });
            }

            if (!_projectVersionService.VersionHasValid(Head.ProjectId, Head.VersionId))
            {
                return Json(new { succeed = false, Message = "نسخه پروژه معتبر نمی باشد" });
            }

            var TestHeader = new TestHeader();

            TestHeader.ProjectId = Head.ProjectId;
            TestHeader.TitleId = 16;
            TestHeader.TestType = TestType.Finctional;
            TestHeader.EntityType = "CodeReview";
            TestHeader.ProjectVersionId = Head.VersionId;

            _testHeaderService.AddHeader(TestHeader, User);


            _notificationService.AddNotification(Head.VersionId, User);


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




            AddCommentOnProject(Head.ProjectId, Head.VersionId, Head.ExpertComment, TypeOfCommand.CodeReview);


            return Json(new { succeed = true, Message = "با موفقیت ثبت شد" });

        }


        public IActionResult DeleteCode(int CodeId)
        {
            _testHeaderService.DeleteCode(CodeId, User);
            var data = _testHeaderService.GetTestHeaders(TestType.Finctional, 16 /*Document Review*/);

            return PartialView("_CodeReviewGrid", data);
        }

        public IActionResult EditCode(int CodeId)
        {
            var Header = _testHeaderService.GetByPk(CodeId);
            var Code = _codeReviewService.GetCodeReviewsByHeaderId(CodeId);
            var CodeDetail = _codeReviewDetailService.GetCodeReviewDetailByCodeId(Code.Id);


            var model = new CreateCodeReviewVM();

            model.ProjectId = Header.ProjectId;
            model.AccurateMatch = Code.AccurateMatch;
            model.AllCountRow = Code.AllCountRow;
            model.HeaderId = Header.Id;
            model.HighMatch = Code.HighMatch;
            model.MatchGroups = Code.MatchGroups;
            model.NormalMatch = Code.NormalMatch;
            model.Offers = Code.Offers;
            model.PoorMatch = Code.PoorMatch;
            model.CodeId = Code.Id;


            model.CodeReviewDetailList = CodeDetail;


            return View(model);
        }


        [HttpPost]
        public IActionResult PostEditCodeReview(CodeReviewVM Head)
        {
            if (Head.ProjectId <= 0)
            {
                return Json(new { succeed = false, Message = "پروژه انتخاب نشده است" });
            }
            var TestHeader  = _testHeaderService.GetByPk(Head.HeaderId);

            TestHeader.ProjectId = Head.ProjectId;
            TestHeader.TitleId = 16;
            TestHeader.TestType = TestType.Finctional;
            TestHeader.EntityType = "CodeReview";

            _testHeaderService.UpdateHeader(TestHeader, User);


            var CodeReview = _codeReviewService.GetCodeReviewsByHeaderId(Head.CodeId);

            CodeReview.AccurateMatch = Head.AccurateMatch;
            CodeReview.AllCountRow = Head.AllCountRow;
            CodeReview.HighMatch = Head.HighMatch;
            CodeReview.MatchGroups = Head.MatchGroups;
            CodeReview.NormalMatch = Head.NormalMatch;
            CodeReview.PoorMatch = Head.PoorMatch;
            CodeReview.TestHeaderId = TestHeader.Id;
            CodeReview.Offers = Head.Offers;
            

            _codeReviewService.UpdateCodeReview(CodeReview, User);


            foreach (var item in Head.CodeReviewDetailList)
            {
                var Detail = _codeReviewDetailService.GetByPK(item.Id);

                Detail.CodeReviewId = CodeReview.Id;
                Detail.Description = item.Description;
                Detail.DetailType = item.DetailType;
                Detail.IndicatorId = item.IndicatorId;
                Detail.Score = item.Score;

                _codeReviewDetailService.UpdateCodeReviewDetail(Detail, User);

            }
            

            return Json(new { succeed = true, Message = "با موفقیت ویرایش شد" });
        }

        public IActionResult ShowCodeModal(int CodeId)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region LoadAndStress

        
        public IActionResult LoadAndStress()
        {
            SelectedSideBar(AccessConst.AddLoadAndStress);


            var Load = _testHeaderService.GetTestHeaders(TestType.Finctional, 9 /*Document Review*/);
            var Stress = _testHeaderService.GetTestHeaders(TestType.Finctional, 10 /*Document Review*/);

            var data = Load.Union(Stress).OrderByDescending(x => x.DateInserted).ToList();

            return View(data);
        }

        public IActionResult CreateStressOrLoadTest()
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value).FirstOrDefault())), "Id", "ProjectName");

            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id", "Description");

            return View();
        }

        [HttpPost]
        public IActionResult CreateStressOrLoadTest(CreateLoadOrStrssTest model)
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");

            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id",
                "Description");

            if (model.TitleId < 0)
            {
                NotifyError("لطفا عنوان تست را انتخاب نمایید");
                return View("CreateStressOrLoadTest");
            }
            if (model.ProjectId < 0)
            {
                NotifyError("لطفا پروژه مورد نظر را انتخاب نمایید");
                return View("CreateStressOrLoadTest");
            }

            if (model.VersionId <= 0)
            {
                NotifyError("نسخه پروژه مشخص نمی باشد");
                return View("CreateStressOrLoadTest");
            }

            if (!_projectVersionService.VersionHasValid(model.ProjectId, model.VersionId))
            {
                NotifyError("نسخه پروژه معتبر نمی باشد");
                return View("CreateStressOrLoadTest");
            }

            var TestHeader = new TestHeader();

            TestHeader.ProjectId = model.ProjectId;
            TestHeader.TitleId = model.TitleId;
            TestHeader.TestType = TestType.Finctional;
            TestHeader.EntityType = "StressAndLoad";
            TestHeader.ProjectVersionId = model.VersionId;

            _testHeaderService.AddHeader(TestHeader,User);


            _notificationService.AddNotification(model.VersionId, User);


            var LoadAndStress = new LoadAndSterss()
            {
                AveTime = model.AveTime,
                Deviation = model.Deviation,
                FailRequest = model.FailRequest,
                SuccessRequest = model.SuccessRequest,
                TestHeaderId = TestHeader.Id,
                Throughput = model.Throughput,
                TotalRequest = model.TotalRequest
            };
            _loadAndSterssService.AddLoadAndStress(LoadAndStress,User);
            
            AddCommentOnProject(model.ProjectId, model.VersionId, model.ExpertComment, TypeOfCommand.Load);

            NotifySuccess("با موفقیت ثبت شد");
            return RedirectToAction("LoadAndStress");
        }

        public IActionResult DeleteStressTest(int TestId)
        {
            _testHeaderService.DeleteStressTest(TestId, User);
            var Load = _testHeaderService.GetTestHeaders(TestType.Finctional, 9 /*Document Review*/);
            var Stress = _testHeaderService.GetTestHeaders(TestType.Finctional, 10 /*Document Review*/);

            var data = Load.Union(Stress).OrderByDescending(x => x.DateInserted).ToList();

            return PartialView("_StressAndLoadGrid", data);
        }

        public IActionResult EditStressTest(int TestId)
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");

            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id",
                "Description");

            var head = _testHeaderService.GetByPk(TestId);

           var Test = _loadAndSterssService.GetByHeaderId(TestId);


           var model = new CreateLoadOrStrssTest()
           {
               ProjectId = head.ProjectId,
               TitleId = head.TitleId,
               HeaderId = TestId,
               TestId = Test.Id,
               AveTime = Test.AveTime,
               Deviation = Test.Deviation,
               FailRequest = Test.FailRequest,
               SuccessRequest = Test.SuccessRequest,
               Throughput = Test.Throughput,
               TotalRequest = Test.TotalRequest
           };

           return View(model);
        }

        public IActionResult EditStressOrLoadTest(CreateLoadOrStrssTest model)
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName",model.ProjectId);

            ViewBag.TestTitle = new SelectList(_lookupService.GetAllByCategory(LookupCategory.Test), "Id",
                "Description",model.TitleId);

            if (model.TitleId < 0)
            {
                NotifyError("لطفا عنوان تست را انتخاب نمایید");
                return View("EditStressTest");
            }
            if (model.ProjectId < 0)
            {
                NotifyError("لطفا پروژه مورد نظر را انتخاب نمایید");
                return View("EditStressTest");
            }

            var head = _testHeaderService.GetByPk(model.HeaderId);

            head.ProjectId = model.ProjectId;
            head.TitleId = model.TitleId;

            _testHeaderService.UpdateHeader(head,User);

            var Test = _loadAndSterssService.GetByHeaderId(model.TestId);

            Test.AveTime = model.AveTime;
            Test.Deviation = model.Deviation;
            Test.FailRequest = model.FailRequest;
            Test.SuccessRequest = model.SuccessRequest;
            Test.Throughput = model.Throughput;
            Test.TotalRequest = model.TotalRequest;

            _loadAndSterssService.UpdateloadAndSterss(Test, User);


            NotifySuccess("با موفقیت ثبت شد");
            return RedirectToAction("LoadAndStress");
        }


        #endregion


        public void AddCommentOnProject(int ProjectId , int VersionId , string Comment , TypeOfCommand type )
        {

            try
            {

                _projectCommentService.AddComment(ProjectId, VersionId, Comment, type , User);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
