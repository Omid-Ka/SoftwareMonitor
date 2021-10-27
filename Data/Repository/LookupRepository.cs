using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
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

        public Lookup GetByPk(int id)
        {
            return _SMContext.Lookups.Find(id);
        }
    }
}
