using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class LookupVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان")]
        public string Description { get; set; }
        [Display(Name = "اطلاعات جامع")]
        public string Information { get; set; }
        [Display(Name = "کد مرجع")]
        public int? ReferenceID { get; set; }
        [Display(Name = "گروه")]
        public LookupCategory Category { get; set; }
        public DateTime? DateInserted { get; set; }  
    }
}
