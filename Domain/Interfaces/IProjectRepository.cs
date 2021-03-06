using Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Domain.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProject();
        bool HasProjectWithName(string projectName);
        Project AddProject(Project model, ClaimsPrincipal user);
        void DeleteUser(int projectId, ClaimsPrincipal user);
        Project GetProjectById(int projectId);
        void EditProject(Project model, ClaimsPrincipal user);
        IEnumerable<Project> GetAllProjectByUserId(int userId);
        IEnumerable<Project> GetAllProjectAssignedByUserId(int userId);
    }
}
