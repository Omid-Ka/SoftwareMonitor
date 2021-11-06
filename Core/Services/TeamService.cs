using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace Core.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public IEnumerable<Team> GetAll()
        {
            return _teamRepository.GetAll();
        }
        public void AddTeam(Team model, ClaimsPrincipal user)
        {
            _teamRepository.AddTeam(model, user);
        }

        public void DeleteTeam(int teamId, ClaimsPrincipal user)
        {
            _teamRepository.DeleteTeam(teamId, user);
        }

        public Team GetTeamById(int teamId)
        {
           return _teamRepository.GetTeamById(teamId);
        }

        public void UpdateTeam(Team model, ClaimsPrincipal user)
        {
            _teamRepository.UpdateTeam(model, user);
        }
    }
}
