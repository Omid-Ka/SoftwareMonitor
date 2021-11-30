using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Core.Services
{
    public class AttachmentService : IAttachmentService
    {
        private IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }
    }
}
