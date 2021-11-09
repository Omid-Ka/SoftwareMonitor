using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Access
{
    public class AccessGroupDetail:BaseEntity
    {
        public int AccessId { get; set; }
        public int AccessGroupId { get; set; }

        public virtual Access Access { get; set; }
        public virtual AccessGroup AccessGroup { get; set; }
    }
}
