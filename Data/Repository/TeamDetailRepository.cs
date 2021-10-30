using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
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

    }
}
