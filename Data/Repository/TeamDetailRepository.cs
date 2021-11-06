using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Data.Repository
{
    public class TeamDetailRepository : ITeamDetailRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public TeamDetailRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddTeamDetail(TeamDetail model, ClaimsPrincipal user)
        {
            var Member =
                _SMContext.TeamDetails.Any(x => x.IsActive && x.TeamId == model.TeamId && x.UserId == model.UserId);
            
            if (!Member)
            {
                model.IsActive = true;
                model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault());
                model.DateInserted = DateTime.Now;
                model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                    .FirstOrDefault();


                _SMContext.Add(model);
                _SMContext.SaveChanges();
            }
        }
        public IEnumerable<TeamDetail> GetAllByTeamId(int teamId)
        {
            return _SMContext.TeamDetails.Where(x => x.IsActive && x.TeamId == teamId);
        }

        public TeamDetail GetByPk(int teamDetailId)
        {
            return _SMContext.TeamDetails.Find(teamDetailId);
        }

        public void DeleteMemberById(int teamDetailId, ClaimsPrincipal user)
        {
            var model = _SMContext.TeamDetails.Find(teamDetailId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

    }
}
