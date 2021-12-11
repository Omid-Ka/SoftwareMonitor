using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Core.DTO
{
    public class ProjectDTO : BaseDTO
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool Selected { get; set; }

        public int Comments { get; set; }
    }
}
