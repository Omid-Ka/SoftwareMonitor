using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Domain.Models.Enum;
using Domain.Models.Projects;

namespace Core.Services
{
    public class ProjectVersionService : IProjectVersionService
    {
        private IProjectVersionRepository _projectVersionRepository;
        private IProjectRepository _projectRepository;

        public ProjectVersionService(IProjectVersionRepository projectVersionRepository, IProjectRepository projectRepository)
        {
            _projectVersionRepository = projectVersionRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<ProjectVersionDTO> GetAllVertion()
        {
            return _projectVersionRepository.GetAllVertion().Select(x=>new ProjectVersionDTO()
            {
                DateInserted = x.DateInserted,
                Id = x.Id,
                Name = x.Name,
                ProjectId = x.ProjectId,
                Status = x.Status,
                ProjectName = _projectRepository.GetProjectById(x.ProjectId).ProjectName
            });
        }


        public void AddVersion(ProjectVersion model, ClaimsPrincipal user)
        {
            _projectVersionRepository.AddVersion(model, user);
        }

        public void DeleteVersion(int versionId, ClaimsPrincipal user)
        {
            _projectVersionRepository.DeleteVersion(versionId,user);
        }

        public ProjectVersion GetByPK(int versionId)
        {
            return _projectVersionRepository.GetByPK(versionId);
        }

        public void EditVersion(ProjectVersion model, ClaimsPrincipal user)
        {
            _projectVersionRepository.EditVersion(model, user);
        }

        public void CloseVersion(int versionId, ClaimsPrincipal user)
        {
            var data = _projectVersionRepository.GetByPK(versionId);
            data.Status = VersionStatus.Close;
            _projectVersionRepository.EditVersion(data,user);
        }

        public IEnumerable<ProjectVersion> GetAllVertionByProjectId(int projectId)
        {
            var data = _projectVersionRepository.GetAllVertion();

            data = data.Where(x => x.IsActive && x.Status == VersionStatus.Open && x.ProjectId == projectId);

            return data;

        }

        public bool VersionHasValid(int projectId, int versionId)
        {
            var data = GetAllVertionByProjectId(projectId);

            return data.Any(x => x.Id == versionId);

        }

        public IEnumerable<ProjectVersionDTO> GetSearchedVertion(string comment)
        {
            return _projectVersionRepository.GetSearchedVertion(comment).Select(x => new ProjectVersionDTO()
            {
                DateInserted = x.DateInserted,
                Id = x.Id,
                Name = x.Name,
                ProjectId = x.ProjectId,
                Status = x.Status,
                ProjectName = _projectRepository.GetProjectById(x.ProjectId).ProjectName
            });
        }
    }
}
