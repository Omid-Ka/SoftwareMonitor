using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;

namespace Domain.Models.ProjectTests
{
    public class TestHeader:BaseEntity
    {
        [Display(Name = "نوع تست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TestType TestType { get; set; }
        [Display(Name = "نوع عنوان تست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TitleId { get; set; }

        public virtual Lookup Title { get; set; }
        
        public int? EntityId { get; set; }
        public string EntityType { get; set; }

        [Display(Name = "پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
