using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class AccountSummary
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserTelNumber { get; set; }
        public string UserLocalTel { get; set; }
        public string CreateUserDate { get; set; }
        public string LastLogin { get; set; }

        public List<ProjectSummary> ProjectList { get; set; }

    }

    public class ProjectSummary 
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
