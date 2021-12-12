using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;
using Domain.Models.Projects;

namespace Core.Interfaces
{
    public interface IProjectCommentService
    {
        void AddComment(int projectId, int versionId, string comment, TypeOfCommand type, ClaimsPrincipal user);
        int CountOfComments(int id);
        List<ProjectComment> GetAllCommentByProjectId(int projectId);
    }
}
