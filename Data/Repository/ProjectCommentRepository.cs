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
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public ProjectCommentRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        
    }
}
