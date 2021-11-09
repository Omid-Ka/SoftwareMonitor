using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Log;
using Core.Helper;
using Domain.Models.Access;

namespace Data.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public AccessRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public IEnumerable<Access> GetAllAccess()
        {
            return _SMContext.Accesses.Where(x => x.IsActive);
        }

        public IEnumerable<Access> GetAllCurrentAccessByGroupId(int id)
        {
            var AccessIds = _SMContext.AccessGroupDetails.Where(x => x.IsActive && x.AccessGroupId == id)
                .Select(x => x.AccessId).ToArray();

            return _SMContext.Accesses.Where(x => x.IsActive && AccessIds.Contains(x.Id));

        }
    }
}
