using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="ثبت کننده")]
        public int CreatorID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ ثبت")]
        public DateTime DateInserted { get; set; }

        [Display(Name = "ویرایش کننده")]
        public int? UpdatedUser { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime? DateModified { get; set; }

        public string IpAddress { get; set; }

        public bool IsActive { get; set; }
    }
}
