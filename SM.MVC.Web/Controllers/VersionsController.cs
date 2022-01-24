using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Projects;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    public class VersionsController : BaseController
    {

        private IProjectVersionService _projectVersionService;
        private IProjectService _projectService;

        public VersionsController(IProjectVersionService projectVersionService, IProjectService projectService)
        {
            _projectVersionService = projectVersionService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            var date = _projectVersionService.GetAllVertion();
            return View(date);
        }

        public IActionResult CreateVersion()
        {
            if (User != null)
            {
                ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateVersion(ProjectVersion model)
        {

            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");

            if (!ModelState.IsValid)
            {
                NotifyError("در ثبت اطلاعات دقت فرمایید");
                return View("CreateVersion", model);
            }
            if (model.ProjectId == 0)
            {
                NotifyError("انتخاب پروژه الزامیست");
                return View("CreateVersion", model);
            }
            if (model.Status == 0)
            {
                NotifyError("انتخاب وضعیت الزامیست");
                return View("CreateVersion", model);
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                NotifyError("شماره نسخه نمیتواند خالی باشد");
                return View("CreateVersion", model);
            }

            _projectVersionService.AddVersion(model, User);


            NotifySuccess("با موفقیت ثبت گردید");
            return RedirectToAction("Index");
        }

        public IActionResult DeleteVersion(int VersionId)
        {

            _projectVersionService.DeleteVersion(VersionId, User);

            var date = _projectVersionService.GetAllVertion();

            NotifySuccess("با موفقیت حذف گردید");
            return PartialView("_VersionGrid", date);
        }

        public IActionResult EditVersion(int VersionId)
        {
            ViewBag.Projects = new SelectList(_projectService.GetAllProjectAssignedByUserId(Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault())), "Id",
                "ProjectName");

            var model = _projectVersionService.GetByPK(VersionId);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditVersion(ProjectVersion model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("در ثبت اطلاعات دقت فرمایید");
                return View("EditVersion", model);
            }
            if (model.ProjectId == 0)
            {
                NotifyError("انتخاب پروژه الزامیست");
                return View("EditVersion", model);
            }
            if (model.Status == 0)
            {
                NotifyError("انتخاب وضعیت الزامیست");
                return View("EditVersion", model);
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                NotifyError("شماره نسخه نمیتواند خالی باشد");
                return View("EditVersion", model);
            }

            _projectVersionService.EditVersion(model, User);


            NotifySuccess("با موفقیت ویرایش گردید");
            return RedirectToAction("Index");
        }

        public IActionResult CloseVersion(int VersionId)
        {

            _projectVersionService.CloseVersion(VersionId, User);

            var date = _projectVersionService.GetAllVertion();

            NotifySuccess("با موفقیت بسته شد");
            return PartialView("_VersionGrid", date);
        }

        public IActionResult VersionDropDownItem(int ProjectId)
        {
            ViewBag.Version = new SelectList(_projectVersionService.GetAllVertionByProjectId(ProjectId), "Id", "Name");

            return PartialView("_VersionDropDownItem");
        }
    }
}
