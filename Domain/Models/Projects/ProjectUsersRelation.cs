using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;

namespace Domain.Models.Projects
{
    public class ProjectUsersRelation:BaseEntity
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual Users User { get; set; }
        public virtual Project Project { get; set; }
    }
}
