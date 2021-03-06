using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models;

namespace Domain.Models.Projects
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام پروژه")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات پروژه")]
        public string ProjectDescription { get; set; }
    }
}
