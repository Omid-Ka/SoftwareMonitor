using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class PartnersRepository : IPartnersRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public PartnersRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

    }
}
