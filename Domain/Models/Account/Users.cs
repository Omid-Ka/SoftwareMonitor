using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.BaseInformation;

namespace Domain.Models.Account
{
    public class Users : BaseEntity
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "پست الکترونیکی")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "کد پرسنلی")]
        public int? PersonnelCode { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Family { get; set; }
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NationalCode { get; set; }
        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GenderId { get; set; }
        public virtual Lookup Gender { get; set; }
        [Display(Name = "پست سازمانی")]
        public int? PostId { get; set; }
        public virtual Lookup Post { get; set; }
        [Display(Name = "تلفن داخلی")]
        public int? LocalTel { get; set; }
        [Display(Name = "شماره تماس")]
        public string MobileNo { get; set; }

    }
}
