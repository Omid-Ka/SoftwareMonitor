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
using Domain.Models.Projects;

namespace Data.Repository
{
    public class ProjectUsersRelationRepository : IProjectUsersRelationRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectUsersRelationRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public List<ProjectUsersRelation> GetAllProjectByUserId(int userId)
        {
            return _SMContext.ProjectUsersRelations.Where(x => x.IsActive && x.UserId == userId).ToList();
        }
    }
}
