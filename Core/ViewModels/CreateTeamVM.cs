using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Teams;

namespace Core.ViewModels
{
    public class CreateTeamVM
    {
        public Team Team { get; set; }
        public List<TeamDetail> Details { get; set; }
    }
}
