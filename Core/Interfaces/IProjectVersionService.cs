using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Teams;
using System.Security.Claims;
using Domain.Models.Projects;
using System.Collections;

namespace Core.Interfaces
{
    public interface IProjectVersionService
    {
        IEnumerable<ProjectVersionDTO> GetAllVertion();
        void AddVersion(ProjectVersion model, ClaimsPrincipal user);
        void DeleteVersion(int versionId, ClaimsPrincipal user);
        ProjectVersion GetByPK(int versionId);
        void EditVersion(ProjectVersion model, ClaimsPrincipal user);
        void CloseVersion(int versionId, ClaimsPrincipal user);
        IEnumerable<ProjectVersion> GetAllVertionByProjectId(int projectId);
        bool VersionHasValid(int projectId, int versionId);
        IEnumerable<ProjectVersionDTO> GetSearchedVertion(string comment);
    }
}
