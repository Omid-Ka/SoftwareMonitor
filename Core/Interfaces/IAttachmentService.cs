using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Teams;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Core.Interfaces
{
    public interface IAttachmentService
    {
        void AddAttachment(List<Attachment> fileList, ClaimsPrincipal user);
        List<Attachment> GetAllFilesByProjectId(int projectId, int versionId);
    }
}
