using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        public IEnumerable<Project> GetProject()
        {
            return _SMContext.Projects;
        }
    }
}
