using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;

namespace Domain.Models.Access
{
    public class UserAccess:BaseEntity  
    {
        public int UserId { get; set; }
        public int AccessId { get; set; }

        public virtual Users User { get; set; }
        public virtual Access Access { get; set; }
    }
}
