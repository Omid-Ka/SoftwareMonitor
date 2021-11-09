using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.ProjectTests
{
    public class CodeReview:BaseEntity
    {
        public int TestHeaderId { get; set; }
        public virtual TestHeader TestHeader { get; set; }
        public int AllCountRow { get; set; }
        public int MatchGroups { get; set; }
        public int AccurateMatch { get; set; }
        public int HighMatch { get; set; }
        public int NormalMatch { get; set; }
        public int PoorMatch { get; set; }

        public string Offers { get; set; }  
    }
}
