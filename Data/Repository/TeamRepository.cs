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
    public class TeamRepository : ITeamRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public TeamRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        public IEnumerable<Team> GetAll()
        {
            return _SMContext.Teams.Where(x => x.IsActive);
        }
        public void AddTeam(Team model, ClaimsPrincipal user)
        {

            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }

        public void DeleteTeam(int teamId, ClaimsPrincipal user)
        {
            var Ip = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();
            var currentuser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            var model = _SMContext.Teams.Find(teamId);
            var Detail = _SMContext.TeamDetails.Where(x => x.IsActive && x.TeamId == teamId).ToList();
            foreach (var item in Detail)
            {
                item.IsActive = false;
                item.UpdatedUser = currentuser;
                item.DateModified = DateTime.Now;
                item.IpAddress = Ip;
                
                _SMContext.TeamDetails.Update(item);
                _SMContext.SaveChanges();
            }

            model.IsActive = false;
            model.UpdatedUser = currentuser;
            model.DateModified = DateTime.Now;
            model.IpAddress = Ip;


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public Team GetTeamById(int teamId)
        {
            return _SMContext.Teams.Find(teamId);
        }

        public void UpdateTeam(Team model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }
        
    }
}
