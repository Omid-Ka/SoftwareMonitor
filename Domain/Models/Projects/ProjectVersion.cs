using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.Projects
{
    public class ProjectVersion : BaseEntity
    {
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        [Display(Name = "نسخه")]
        public string Name { get; set; }
        [Display(Name = "وضعیت")]
        public VersionStatus Status { get; set; }
    }
}
