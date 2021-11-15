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
using Domain.Models.ProjectTests;

namespace Data.Repository
{
    public class TestHeaderRepository : ITestHeaderRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public TestHeaderRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public List<TestHeader> GetTestHeaders(TestType testType, int testId)
        {
            return _SMContext.TestHeaders.Where(x => x.IsActive && x.TestType == testType && x.TitleId == testId)
                .ToList();
        }
    }
}
