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
    }
}
