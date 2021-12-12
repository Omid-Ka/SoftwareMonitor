using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Domain.Interfaces
{
    public interface IAttachmentRepository
    {
        void AddAttachment(Attachment attachment, ClaimsPrincipal user);
        List<Attachment> GetAllFilesByProjectId(int projectId, int versionId);
    }
}
