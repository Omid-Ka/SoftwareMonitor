using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Core.Services
{
    public class AttachmentService : IAttachmentService
    {
        private IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public void AddAttachment(List<Attachment> fileList, ClaimsPrincipal user)
        {
            foreach (var attachment in fileList)
            {
                _attachmentRepository.AddAttachment(attachment, user);
            }
        }

        public List<Attachment> GetAllFilesByProjectId(int projectId, int versionId)
        {
            return _attachmentRepository.GetAllFilesByProjectId(projectId, versionId);
        }
    }
}
