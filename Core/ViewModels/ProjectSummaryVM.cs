using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;
using Domain.Models;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class ProjectSummaryVM
    {
        public Project Project { get; set; }
        public List<ShowPartnersVM> Partners { get; set; }
    }

    public class ShowPartnersVM
    {
        [Display(Name = "نوع همکاری")]
        public PartnerTeam PartnerTeam { get; set; }

        public string PartnerTeamDesc => PartnerTeam.ToDescription();

        public List<UserVM> Users { get; set; }
        public string AllUserName { get; set; }
    }
}
