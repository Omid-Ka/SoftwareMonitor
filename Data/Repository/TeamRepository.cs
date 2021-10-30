using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
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

    }
}
