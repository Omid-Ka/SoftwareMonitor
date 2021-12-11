using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        private IProjectService _projectService;
        private IProjectCommentService _projectCommentService;

        public CommentController(IProjectService projectService, IProjectCommentService projectCommentService)
        {
            _projectService = projectService;
            _projectCommentService = projectCommentService;
        }

        public IActionResult Index()
        {

            var Projects = _projectService.GetAllProject(User);

            foreach (var item in Projects)
            {
                item.Comments = _projectCommentService.CountOfComments(item.Id);
            }

            return View(Projects);
        }


        public IActionResult Comments()
        {
            return View();
        }
    }
}
