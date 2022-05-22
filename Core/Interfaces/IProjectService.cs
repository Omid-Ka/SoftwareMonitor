using Core.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Domain.Models;
using System.Collections;

namespace Core.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetAllProject(ClaimsPrincipal user);
        bool HasProjectWithName(string projectName);
        Project AddProject(Project model, ClaimsPrincipal user);
        void DeleteProject(int ProjectId, ClaimsPrincipal user);
        Project GetProjectById(int projectId);
        void EditProject(Project model, ClaimsPrincipal user);
        IEnumerable<Project> GetAllProjectByUserId(int userId);
        List<ProjectDTO> GetAllProjectForAccess(int userId);
        IEnumerable<Project> GetAllProjectAssignedByUserId(int v);
    }
}
