using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface ITeamDetailRepository
    {
        void AddTeamDetail(TeamDetail model, ClaimsPrincipal user);
        IEnumerable<TeamDetail> GetAllByTeamId(int teamId);
        TeamDetail GetByPk(int teamDetailId);
        void DeleteMemberById(int teamDetailId, ClaimsPrincipal user);
    }
}
