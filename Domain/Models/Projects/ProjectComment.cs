using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Mail;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.Projects
{
    public class ProjectComment : BaseEntity
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Comment { get; set; }
        [Display(Name = "ورژن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int VersionId { get; set; }
        [Display(Name = "پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProjectId { get; set; }
        [Display(Name = "درجه اهمیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public PriorityType Priority { get; set; }
        [Display(Name = "نوع نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TypeOfCommand CommandType { get; set; }

        public virtual ProjectVersion Version { get; set; }
        public virtual Project Project { get; set; }
    }
}
