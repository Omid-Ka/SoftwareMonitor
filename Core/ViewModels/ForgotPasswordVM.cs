using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class ForgotPasswordVM
    {
        [Display(Name = "پست الکترونیکی")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
