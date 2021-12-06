using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Domain.Models.Account
{
    public class Notification : BaseEntity
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ReciverUserId { get; set; }
        public int? EntityId { get; set; }
        public string EntityType { get; set; }
        public bool Seen { get; set; }
    }
}
