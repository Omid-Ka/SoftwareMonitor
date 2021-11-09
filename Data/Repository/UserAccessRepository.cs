﻿using Domain.Interfaces;
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

namespace Data.Repository
{
    public class UserAccessRepository : IUserAccessRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public UserAccessRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        
    }
}
