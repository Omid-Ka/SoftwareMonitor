using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Core.ViewModels;
using Domain.Models.Projects;

namespace Core.DTO
{
    public class ProjectDTO : BaseDTO
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool Selected { get; set; }

        public int Comments { get; set; }

        public List<ProjectVersionDTO> VersionList { get; set; }
    }
}
