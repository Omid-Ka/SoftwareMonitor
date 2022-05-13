using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Access
{
    public class SelectedAccess:BaseEntity
    {
        public int UserId { get; set; }
        public string Access { get; set; }
    }
}
