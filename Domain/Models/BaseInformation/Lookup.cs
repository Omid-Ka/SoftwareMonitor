using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.BaseInformation
{
    public class Lookup : BaseEntity
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        public string Description { get; set; }

        [Display(Name = "اطلاعات جامع")]
        public string Information  { get; set; }

        [Display(Name = "کد مرجع")]
        public int? ReferenceID { get; set; }
        [Display(Name = "گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public LookupCategory Category { get; set; }
    }
}
