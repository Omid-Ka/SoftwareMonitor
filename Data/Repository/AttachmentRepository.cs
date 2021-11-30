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
    public class AttachmentRepository : IAttachmentRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public AttachmentRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        
        
    }
}
