using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.Projects
{
    public class ProjectVersion : BaseEntity
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public VersionStatus Status { get; set; }
    }
}
