using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Account;

namespace Domain.Models.Teams
{
    public class TeamDetail:BaseEntity
    {
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [Display(Name = "اعضاء")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? UserId { get; set; }
        public virtual Users User { get; set; }

        [Display(Name = "سمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Position { get; set; }

    }
}
