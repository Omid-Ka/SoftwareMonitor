using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM.MVC.Web.Controllers
{
    //[Authorize]
    public class ProjectController : BaseController
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var data = _projectService.GetAllProject();
            return View(data);
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project model)
        {

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateProject");
            }

            bool HasUser = _projectService.HasProjectWithName(model.ProjectName);
            if (HasUser)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateProject");
            }


            _projectService.AddProject(model, User);

            NotifyError("با موفقیت ثبت شد");
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int ProjectId)
        {
            _projectService.DeleteProject(ProjectId, User);

            var data = _projectService.GetAllProject();

            return PartialView("_ProjectGrid", data);
        }


        public IActionResult EditProject(int ProjectId)
        {
            var model = _projectService.GetProjectById(ProjectId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProject(Project model)
        {

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateProject");
            }

            //bool HasUser = _usersService.HasUserWithUserName(model.UserName);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithNationalcode(model.NationalCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}
            //HasUser = _usersService.HasUserWithPersonnelCode(model.PersonnelCode);
            //if (HasUser)
            //{
            //    NotifyError("اطلاعات کاربر تکراری می باشد");
            //    return View("CreateUser");
            //}

            _projectService.EditProject(model, User);

            NotifyError("با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }
    }
}
