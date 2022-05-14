using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Domain.Interfaces
{
    public interface IProjectVersionRepository
    {
        IEnumerable<ProjectVersion> GetAllVertion();
        void AddVersion(ProjectVersion model, ClaimsPrincipal user);
        void DeleteVersion(int versionId, ClaimsPrincipal user);
        ProjectVersion GetByPK(int versionId);
        void EditVersion(ProjectVersion model, ClaimsPrincipal user);
        IEnumerable<ProjectVersion> GetSearchedVertion(string comment);
        string GetByTestHeaderId(int testHeaderId);
    }
}
