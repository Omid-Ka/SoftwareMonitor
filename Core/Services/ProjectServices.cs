using Core.DTO;
using Core.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class ProjectServices : IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public ProjectDTO GetProject()
        {
            return new ProjectDTO()
            {
                Id = 1,
                CreatorID = 1 ,
                DateInserted = DateTime.Now,
                ProjectName = "test",
                ProjectDescription = "TestDesc"
            };
        }
    }
}
