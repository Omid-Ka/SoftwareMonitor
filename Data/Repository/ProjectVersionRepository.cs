using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using Domain.Models.Projects;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Data.Repository
{
    public class ProjectVersionRepository : IProjectVersionRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectVersionRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddVersion(ProjectVersion model, ClaimsPrincipal user)
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

        public void DeleteVersion(int versionId, ClaimsPrincipal user)
        {
            var model = _SMContext.ProjectVersion.Find(versionId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
            //    .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public IEnumerable<ProjectVersion> GetAllVertion()
        {
            return _SMContext.ProjectVersion.Where(x => x.IsActive);
        }

        public ProjectVersion GetByPK(int versionId)
        {
            return _SMContext.ProjectVersion.Find(versionId);
        }

        public void EditVersion(ProjectVersion model, ClaimsPrincipal user)
        {

            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public IEnumerable<ProjectVersion> GetSearchedVertion(string comment)
        {
            var CommentList = _SMContext.ProjectComment.Where(x => x.IsActive && x.Comment.Contains(comment))
                .Select(x => x.VersionId).Distinct();


            var version = _SMContext.ProjectVersion.Where(x => x.IsActive && x.Name.Contains(comment)).Select(x => x.Id)
                .Distinct();

            var VIds = CommentList.Union(version).Distinct().ToArray();

            var data = _SMContext.ProjectVersion.Where(x => x.IsActive && VIds.Contains(x.Id));

            return data;

        }

        public string GetByTestHeaderId(int testHeaderId)
        {
            var Header = _SMContext.TestHeaders.Find(testHeaderId);
            var version = _SMContext.ProjectVersion.Find(Header.ProjectVersionId);

            return version.Name;
        }
    }
}
