using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class CreateAccesGroupVM
    {
        public int AccessGroupId { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroupName { get; set; }
        public List<AccessVM> Accesses { get; set; }
    }

    public class AccessVM
    {
        public int AccessId { get; set; }
        public string AccessName { get; set; }
        public bool Selected { get; set; }
    }
}
