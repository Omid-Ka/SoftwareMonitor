using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public IEnumerable<Project> GetAllProject()
        {
            return _SMContext.Projects.Where(x=>x.IsActive);
        }

        public bool HasProjectWithName(string projectName)
        {
            return _SMContext.Projects.Any(x => x.ProjectName == projectName && x.IsActive);
        }

        public void AddProject(Project model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }

        public void DeleteUser(int projectId, ClaimsPrincipal user)
        {
            var model = _SMContext.Projects.Find(projectId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
            //    .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public Project GetProjectById(int projectId)
        {
            return _SMContext.Projects.Find(projectId);
        }

        public void EditProject(Project model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjectByUserId(int userId)
        {
            var UserTeam = _SMContext.TeamDetails.Where(x => x.IsActive && x.UserId == userId).Select(x => x.TeamId)
                .ToArray();
            var data = _SMContext.Partners
                .Where(x => x.IsActive && (x.UserId == userId || UserTeam.Contains(x.TeamId.Value)))
                .Select(x => x.Project);

            return data;
        }
    }
}
