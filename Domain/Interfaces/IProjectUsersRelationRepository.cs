using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Domain.Interfaces
{
    public interface IProjectUsersRelationRepository
    {
        List<ProjectUsersRelation> GetAllProjectByUserId(int userId);
        void RemoveAccess(int projectId, int userid, ClaimsPrincipal user);
        void AddedAccess(int projectId, int userid, ClaimsPrincipal user);
        int[] GetAllUserByProjectId(int projectId);
        void AddProjectAccess(Project project, ClaimsPrincipal user);
    }
}
