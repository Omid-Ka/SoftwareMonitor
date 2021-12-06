using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class ProjectVersionDTO
    {   
        public int Id { get; set; }
        public DateTime DateInserted { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Name { get; set; }
        public VersionStatus Status { get; set; }
    }
}
