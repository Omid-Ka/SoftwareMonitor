using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;
using Domain.Models.Enum;
using Domain.Models.Teams;

namespace Domain.Models.Projects
{
    public class Partners:BaseEntity
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public PartnerTeam PartnerTeam { get; set; }
        public int? UserId { get; set; }
        public virtual Users User { get; set; }
        public int? TeamId { get; set; }
        public virtual Teams.Team Team { get; set; }

    }
}
