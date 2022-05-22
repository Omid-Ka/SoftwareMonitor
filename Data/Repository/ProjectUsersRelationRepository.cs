using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Log;
using Core.Helper;
using Domain.Models.Projects;

namespace Data.Repository
{
    public class ProjectUsersRelationRepository : IProjectUsersRelationRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectUsersRelationRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public List<ProjectUsersRelation> GetAllProjectByUserId(int userId)
        {
            return _SMContext.ProjectUsersRelations.Where(x => x.IsActive && x.UserId == userId).ToList();
        }

        public void RemoveAccess(int projectId, int userid, ClaimsPrincipal user)
        {
            var Access =
                _SMContext.ProjectUsersRelations.FirstOrDefault(x =>
                    x.IsActive && x.ProjectId == projectId && x.UserId == userid);

            if (Access != null)
            {
                Access.IsActive = false;
                Access.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault());
                Access.DateModified = DateTime.Now;
                //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                //    .FirstOrDefault();


                _SMContext.Update(Access);
            }

            _SMContext.SaveChanges();

        }



        public void AddedAccess(int projectId, int userid, ClaimsPrincipal user)
        {
            var model = new ProjectUsersRelation();

            model.ProjectId = projectId;
            model.UserId = userid;
            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();


        }

        public int[] GetAllUserByProjectId(int projectId)
        {
            var list = _SMContext.ProjectUsersRelations.Where(x => x.IsActive && x.ProjectId == projectId)
                .Select(x => x.UserId).Distinct().ToArray();

            return list;
        }

        public void AddProjectAccess(Project project, ClaimsPrincipal user)
        {
            var model = new ProjectUsersRelation();
            var userid = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            model.ProjectId = project.Id;
            model.UserId = userid;
            model.IsActive = true;
            model.CreatorID = userid;
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }
    }
}
