using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Data.Migrations;
using Domain.Models;
using Domain.Models.Enum;
using Domain.Models.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{

    [Authorize]
    public class ProjectController : BaseController
    {
        private IProjectService _projectService;
        private IUsersService _usersService;
        private ITeamService _teamService;
        private IPartnersService _partnersService;

        public ProjectController(IProjectService projectService, IUsersService usersService, ITeamService teamService, IPartnersService partnersService)
        {
            _projectService = projectService;
            _usersService = usersService;
            _teamService = teamService;
            _partnersService = partnersService;
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

            ViewBag.Teams = new SelectList(_teamService.GetAll(), "Id",
                "Name");


            var model = new CreateProjectVM();
            model.Partners = new List<PartnerVM>();
            model.Partners.Add(null);

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

            bool HasProject = _projectService.HasProjectWithName(model.Project.ProjectName);
            if (HasProject)
            {
                NotifyError("اطلاعات کاربر تکراری می باشد");
                return View("CreateProject");
            }


            _projectService.AddProject(model.Project, User);


            if (model.Partners.Count > 0)
            {
                foreach (var item in model.Partners)
                {
                    if (item.UserId > 0 || item.TeamId > 0)
                    {
                        var Partners = new Partners()
                        {
                            ProjectId = model.Project.Id,
                            TeamId = item.TeamId,
                            UserId = item.UserId
                        };
                        _partnersService.AddPartner(Partners, User);
                    }
                }
            }

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
            var data = _projectService.GetProjectById(ProjectId);

            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            ViewBag.Teams = new SelectList(_teamService.GetAll(), "Id",
                "Name");


            var model = new CreateProjectVM();
            model.Project = data;
            model.Partners = _partnersService.GetAllPartnerVMByProjectId(ProjectId);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProject(CreateProjectVM model)
        {

            if (!ModelState.IsValid)
            {
                NotifyError("خطا در ثبت اطلاعات");
                return View("CreateProject");
            }

            _projectService.EditProject(model.Project, User);

            //if (model.Partners.Count > 0)
            //{
            //    foreach (var item in model.Partners)
            //    {
            //        if (item.UserId > 0 || item.TeamId > 0)
            //        {
            //            var Partners = new Partners()
            //            {
            //                ProjectId = model.Project.Id,
            //                TeamId = item.TeamId,
            //                UserId = item.UserId,
            //                Id = item.Id.HasValue ? item.Id.Value : 0
            //            };
            //            _partnersService.UpdatePartner(Partners, User);
            //        }
            //    }
            //}


            NotifyError("با موفقیت ویرایش شد");
            return RedirectToAction("Index");
        }


        public IActionResult SummaryStatus(int ProjectId)
        {
            var model = new ProjectSummaryVM();

            model.Project = _projectService.GetProjectById(ProjectId);

            model.Partners = _partnersService.GetAllPartnerInProjectByProjectId(ProjectId);



            return PartialView("_ProjectSummaryStatus", model);
        }

        public IActionResult DeletePartners(int PartnerId)
        {
            return null;
        }

        public IActionResult AddPartners(int ProjectId)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            ViewBag.Teams = new SelectList(_teamService.GetAll(), "Id",
                "Name");

            var model = new CreateProjectVM();
            model.Project = new Project() { Id = ProjectId };
            model.Partners = _partnersService.GetAllPartnerVMByProjectId(ProjectId);
            model.Partners.Add(new PartnerVM()
            {
                ProjectId = ProjectId
            });
            return PartialView("_AddPartners", model);
        }

        public IActionResult FinalAddPartners(CreateProjectVM model)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            ViewBag.Teams = new SelectList(_teamService.GetAll(), "Id",
                "Name");

            if (model.Partners.Count > 0)
            {
                foreach (var item in model.Partners)
                {
                    if (item.UserId > 0 || item.TeamId > 0)
                    {
                        var Partners = new Partners();
                        if (item.UserId > 0 && item.TeamId > 0)
                        {
                            Partners = new Partners()
                            {
                                ProjectId = model.Project.Id,
                                TeamId = item.TeamId
                            };

                        }
                        else
                        {
                            Partners = new Partners()
                            {
                                ProjectId = model.Project.Id,
                                UserId = item.UserId
                            };
                        }
                        _partnersService.AddPartner(Partners, User);
                    }
                }
            }

            NotifyError("با موفقیت ثبت شد");
            return PartialView("_AddPartners", model);
        }

        public IActionResult AddSubPartner(CreateProjectVM Model)
        {
            ViewBag.Users = new SelectList(_usersService.GetAllUsers(), "Id",
                "FullName");

            ViewBag.Teams = new SelectList(_teamService.GetAll(), "Id",
                "Name");

            Model.Partners.Add(null);

            return PartialView("_SubPartner", Model);
        }

        public IActionResult AddAttachment(int ProjectId)
        {
            var model = new Attachment()
            {
                ProjectId = ProjectId
            };
            return PartialView("_AddAttachment", model);
        }

        public IActionResult FinalAddAttachment()
        {
            throw new NotImplementedException();
        }
    }
}
