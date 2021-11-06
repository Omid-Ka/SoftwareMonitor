using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Teams;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface ITeamDetailService
    {
        void AddTeamDetail(TeamDetail item, ClaimsPrincipal user);
        List<TeamDetailVM> GetAllByTeamId(int teamId);
        List<TeamDetail> GetAllItemsByTeamId(int teamId);
        TeamDetail GetByPk(int teamDetailId);
        void DeleteMemberById(int teamDetailId, ClaimsPrincipal user);
    }
}
