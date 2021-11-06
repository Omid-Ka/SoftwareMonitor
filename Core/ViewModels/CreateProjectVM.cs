using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class CreateProjectVM
    {
        public Project Project { get; set; }
        public List<PartnerVM> Partners { get; set; }
    }


    public class PartnerVM
    {
        [Display(Name = "نوع همکاری")]
        public PartnerTeam PartnerTeam { get; set; }
        public int? ProjectId { get; set; }
        [Display(Name = "کاربر")]
        public int? UserId { get; set; }
        [Display(Name = "تیم")]
        public int? TeamId { get; set; }
    }
}
