using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Projects;

namespace Core.ViewModels
{
    public class AttachmentDTO
    {
        public List<AttachTypes> Types { set; get; }
        public Attachment Attachment { set; get; }
    }

    public class AttachTypes
    {
        public bool IsSelected { get; set; }    
        public AttachmentType Type { get; set; }
    }
}
