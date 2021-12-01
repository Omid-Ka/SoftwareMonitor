using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Core.Services
{
    public class ProjectVersionService : IProjectVersionService
    {
        private IProjectVersionRepository _projectVersionRepository;

        public ProjectVersionService(IProjectVersionRepository projectVersionRepository)
        {
            _projectVersionRepository = projectVersionRepository;
        }
    }
}
