using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM.MVC.Web.Controllers
{
    //[Authorize]
    public class ProjectController : BaseController
    {
        private IProjectService _projectService;
        private IUsersService _usersService;
        private ITeamService _teamService;

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
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            ViewBag.Teams = new SelectList(_teamService.GetAll() , "Id",
                "Name");

            var model = new CreateProjectVM();
            model.Partners = new List<PartnerVM>();

            foreach (PartnerTeam type in Enum.GetValues(typeof(PartnerTeam)))
            {
                model.Partners.Add(new PartnerVM()
                {
                    PartnerTeam = type
                });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectVM model)
        {

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateProject");
            }

            bool HasUser = _projectService.HasProjectWithName(model.Project.ProjectName);
            if (HasUser)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateProject");
            }


            _projectService.AddProject(model.Project, User);

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


        public IActionResult Partners(int ProjectId)
        {
            return null;
        }

        public IActionResult DeletePartners (int PartnerId)
        {
            return null;
        }

        public IActionResult AddPartners(int ProjectId)
        {
            return null;
        }

        public IActionResult FinalAddPartners(int ProjectId)
        {
            return null;
        }

    }
}
