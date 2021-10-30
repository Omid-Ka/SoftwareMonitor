using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Log;

namespace Data.Repository
{
    public class UserLogRepository : IUserLogRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public UserLogRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public UserLog GetByPk(int id)
        {
            return _SMContext.UserLogs.Find(id);
        }
    }
}
