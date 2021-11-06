using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class TeamDetailService : ITeamDetailService
    {
        private ITeamDetailRepository _teamDetailRepository;
        private IUsersRepository _usersRepository;

        public TeamDetailService(ITeamDetailRepository teamDetailRepository, IUsersRepository usersRepository)
        {
            _teamDetailRepository = teamDetailRepository;
            _usersRepository = usersRepository;
        }

        public void AddTeamDetail(TeamDetail model, ClaimsPrincipal user)
        {
            _teamDetailRepository.AddTeamDetail(model, user);
        }
        public List<TeamDetailVM> GetAllByTeamId(int teamId)
        {
            return _teamDetailRepository.GetAllByTeamId(teamId).Select(x=> new TeamDetailVM(){
                Id = x.Id,
                TeamId = x.TeamId,
                UserId = x.UserId,
                Position = x.Position,
                Member = x.UserId.HasValue ? _usersRepository.GetFullNameById(x.UserId.Value) : ""
            }).ToList();
        }

        public List<TeamDetail> GetAllItemsByTeamId(int teamId)
        {
            return _teamDetailRepository.GetAllByTeamId(teamId).ToList();
        }

        public TeamDetail GetByPk(int teamDetailId)
        {
            return _teamDetailRepository.GetByPk(teamDetailId);
        }

        public void DeleteMemberById(int teamDetailId, ClaimsPrincipal user)
        {
            _teamDetailRepository.DeleteMemberById(teamDetailId, user);
        }

    }
}
