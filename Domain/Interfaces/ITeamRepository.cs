using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        void AddTeam(Team model, ClaimsPrincipal user);
        void DeleteTeam(int teamId, ClaimsPrincipal user);
        Team GetTeamById(int teamId);
        void UpdateTeam(Team model, ClaimsPrincipal user);
    }
}
