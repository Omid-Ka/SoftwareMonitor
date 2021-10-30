using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;

namespace Domain.Models.Teams
{
    public class TeamDetail:BaseEntity
    {
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int? UserId { get; set; }
        public virtual Users User { get; set; }

    }
}
