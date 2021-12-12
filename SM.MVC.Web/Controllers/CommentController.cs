using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Helper;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using SM.MVC.Web.Modules;

namespace SM.MVC.Web.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        private IProjectService _projectService;
        private IProjectCommentService _projectCommentService;
        private IProjectVersionService _projectVersionService;
        private IUsersService _usersService;

        public CommentController(IProjectService projectService, IProjectCommentService projectCommentService, IProjectVersionService projectVersionService, IUsersService usersService)
        {
            _projectService = projectService;
            _projectCommentService = projectCommentService;
            _projectVersionService = projectVersionService;
            _usersService = usersService;
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
            var data = _projectVersionService.GetAllVertion().ToList();
            return View(data);
        }

        public IActionResult ShowConversation(int ProjectId,int VersionId)
        {
            var UserId = Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            var model = new ConversationDTO();

            var Project = _projectService.GetProjectById(ProjectId);
            var Comments = _projectCommentService.GetAllCommentByProjectId(ProjectId).Where(x=>x.VersionId == VersionId);

            model.ProjectId = ProjectId;
            model.versionId = VersionId;
            model.ProjectName = Project.ProjectName;
            model.ConversationDetails = new List<ConversationDetail>();

            foreach (var projectComment in Comments)
            {
                var Creator = _usersService.GetUserById(projectComment.CreatorID);


                model.ConversationDetails.Add(new ConversationDetail()
                {
                    Description = projectComment.Comment,
                    SendDate = projectComment.DateInserted.GetPrsianDate(),
                    SendedUser = Creator.Name +""+ Creator.Family,
                    IsMine = (Creator.Id == UserId) ? true : false ,
                    Type = projectComment.CommandType

                });
            }

            return PartialView("_Conversation", model);
        }

        public IActionResult SendComment(string Text , int ProjectId , int VersionId)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                _projectCommentService.AddComment(ProjectId, VersionId, Text, TypeOfCommand.Other, User);
            }

            return PartialView("_empty");

        }
    }
}
