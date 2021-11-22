using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.Log
{
    public class UserLog:BaseEntity
    {
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public UserLogType Type { get; set; }
    }
}
