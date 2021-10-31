using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using Domain.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
