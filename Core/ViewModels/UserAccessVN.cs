using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Access;

namespace Core.ViewModels
{
    public class UserAccessVN
    {
        public AccessGroup AccessGroup { get; set; }
        public List<AccessGroupDetail> AccessGroupDetails { get; set; }
    }
}
