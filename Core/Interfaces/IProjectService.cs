using Core.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Domain.Models;

namespace Core.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetAllProject();
        bool HasProjectWithName(string projectName);
        void AddProject(Project model, ClaimsPrincipal user);
        void DeleteProject(int ProjectId, ClaimsPrincipal user);
        Project GetProjectById(int projectId);
        void EditProject(Project model, ClaimsPrincipal user);
        IEnumerable<Project> GetAllProjectByUserId(int userId);
    }
}
