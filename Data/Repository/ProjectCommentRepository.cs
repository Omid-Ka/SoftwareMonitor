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
using Domain.Models.Access;
using Domain.Models.Projects;

namespace Data.Repository
{
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectCommentRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddComment(ProjectComment model, ClaimsPrincipal user)
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

        public int CountOfComments(int id)
        {
            return _SMContext.ProjectComment.Count(x => x.IsActive && x.ProjectId == id);
        }

        public List<ProjectComment> GetAllCommentByProjectId(int projectId)
        {
            return _SMContext.ProjectComment.Where(x => x.IsActive && x.ProjectId == projectId).ToList();
        }
    }
}
