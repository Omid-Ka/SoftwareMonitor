using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class LookupRepository : ILookupRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public LookupRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        
    }
}
