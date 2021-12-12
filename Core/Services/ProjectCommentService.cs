using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;
using Domain.Models.Projects;

namespace Core.Services
{
    public class ProjectCommentService : IProjectCommentService
    {

        private IProjectCommentRepository _projectCommentRepository;

        public ProjectCommentService(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }

        public void AddComment(int projectId, int versionId, string comment, TypeOfCommand type, ClaimsPrincipal user)
        {
            var model = new ProjectComment()
            {
                VersionId = versionId,
                Comment = comment,
                CommandType = type,
                ProjectId = projectId
            };

            _projectCommentRepository.AddComment(model,user);

        }

        public int CountOfComments(int id)
        {
            return _projectCommentRepository.CountOfComments(id);
        }

        public List<ProjectComment> GetAllCommentByProjectId(int projectId)
        {
            return _projectCommentRepository.GetAllCommentByProjectId(projectId);
        }
    }
}
