using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.Projects
{
    public class Attachment : BaseEntity
    {

        public int ProjectId { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public int Length { get; set; }

        public AttachmentType Type { get; set; }

        public virtual  Project Project { get; set; }
    }
}
