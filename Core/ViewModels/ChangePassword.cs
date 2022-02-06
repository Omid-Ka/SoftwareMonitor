using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class ChangePassword
    {
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("NewPassword", ErrorMessage = "تکرار کلمه عبور مطابق کلمه عبور انتخابی نمی باشد")]
        [DataType(DataType.Password)]
        public string RePassworld { get; set; }
    }
}
