using Core.DTO;
using Core.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class ProjectServices : IProjectService
    {
        private IProjectRepository _projectRepository;
        private IProjectUsersRelationRepository _projectUsersRelationRepository;

        public ProjectServices(IProjectRepository projectRepository, IProjectUsersRelationRepository projectUsersRelationRepository)
        {
            _projectRepository = projectRepository;
            _projectUsersRelationRepository = projectUsersRelationRepository;
        }

        public IEnumerable<ProjectDTO> GetAllProject(ClaimsPrincipal user)
        {
            var UserId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            return _projectRepository.GetAllProjectAssignedByUserId(UserId).Select(x => new ProjectDTO()
            {
                Id = x.Id,
                CreatorID = x.CreatorID,
                DateInserted = x.DateInserted,
                ProjectName = x.ProjectName,
                ProjectDescription = x.ProjectDescription
            });

            //return _projectRepository.GetAllProject().Select(x=>new ProjectDTO()
            //{
            //    Id = x.Id,
            //    CreatorID = x.CreatorID,
            //    DateInserted = x.DateInserted,
            //    ProjectName = x.ProjectName,
            //    ProjectDescription = x.ProjectDescription
            //});
        }

        public bool HasProjectWithName(string projectName)
        {
            return _projectRepository.HasProjectWithName(projectName);
        }

        public void AddProject(Project model, ClaimsPrincipal user)
        {
            _projectRepository.AddProject(model, user);
        }

        public void DeleteProject(int ProjectId, ClaimsPrincipal user)
        {
            _projectRepository.DeleteUser(ProjectId, user);
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetProjectById(projectId);
        }

        public void EditProject(Project model, ClaimsPrincipal user)
        {
            _projectRepository.EditProject(model, user);
        }

        public IEnumerable<Project> GetAllProjectByUserId(int userId)
        {
            return _projectRepository.GetAllProjectByUserId(userId);
        }

        public List<ProjectDTO> GetAllProjectForAccess(int userId)
        {
            var AllProject = _projectRepository.GetAllProject();
            var AllUserProject = _projectUsersRelationRepository.GetAllProjectByUserId(userId);

            return AllProject.Select(x => new ProjectDTO()
            {
                Id = x.Id,
                CreatorID = x.CreatorID,
                DateInserted = x.DateInserted,
                ProjectName = x.ProjectName,
                ProjectDescription = x.ProjectDescription,
                Selected = (AllUserProject.Any(z=>z.ProjectId == x.Id)) ? true : false
            }).ToList();

        }

        public IEnumerable<Project> GetAllProjectAssignedByUserId(int userId)
        {
            return _projectRepository.GetAllProjectAssignedByUserId(userId);
        }
    }
}
