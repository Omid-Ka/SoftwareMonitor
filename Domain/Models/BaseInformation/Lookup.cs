using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.BaseInformation
{
    public class Lookup : BaseEntity
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        public string Description { get; set; }

        [Display(Name = "اطلاعات جامع2")]
        public string Information  { get; set; }

        public int? ReferenceID { get; set; }

        public int Category { get; set; }
    }
}
