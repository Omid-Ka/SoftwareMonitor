using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;

namespace Domain.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
    }
}
