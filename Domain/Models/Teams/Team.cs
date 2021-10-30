using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Teams
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
