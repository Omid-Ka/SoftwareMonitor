using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.MVC.Web.Modules;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SM.MVC.Web.Controllers
{
    [Authorize]
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
            ProjectDTO ModelDTO = _projectService.GetProject();
            return View(ModelDTO);
        }
    }
}
