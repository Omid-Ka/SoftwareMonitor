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
    public class AttachmentRepository : IAttachmentRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public AttachmentRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddAttachment(Attachment model, ClaimsPrincipal user)
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

        public List<Attachment> GetAllFilesByProjectId(int projectId, int versionId)
        {
            return _SMContext.Attachment.Where(x => x.IsActive && x.ProjectId == projectId && x.VersionId == versionId).ToList();
        }
    }
}
