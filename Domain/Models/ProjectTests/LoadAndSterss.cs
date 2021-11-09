using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace Domain.Models.ProjectTests
{
    public class LoadAndSterss:BaseEntity
    {
        public int TestHeaderId { get; set; }
        public virtual TestHeader TestHeader { get; set; }
        public int TotalRequest { get; set; }
        public int SuccessRequest { get; set; }
        public int FailRequest { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AveTime { get; set; }

    }
}
