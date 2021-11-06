using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Teams;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAll();
        void AddTeam(Team model, ClaimsPrincipal user);
        void DeleteTeam(int teamId, ClaimsPrincipal user);
        Team GetTeamById(int teamId);
        void UpdateTeam(Team model, ClaimsPrincipal user);
    }
}
