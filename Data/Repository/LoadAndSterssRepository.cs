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
using Domain.Models.ProjectTests;

namespace Data.Repository
{
    public class LoadAndSterssRepository : ILoadAndSterssRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public LoadAndSterssRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddLoadAndStress(LoadAndSterss loadAndStress, ClaimsPrincipal user)
        {
            loadAndStress.IsActive = true;
            loadAndStress.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            loadAndStress.DateInserted = DateTime.Now;
            loadAndStress.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(loadAndStress);
            _SMContext.SaveChanges();
        }

        public void DeleteStressTest(int testId, ClaimsPrincipal user)
        {
            var model = _SMContext.LoadAndStersses.FirstOrDefault(x=>x.IsActive && x.TestHeaderId == testId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public LoadAndSterss GetByHeaderId(int testId)
        {
            return _SMContext.LoadAndStersses.FirstOrDefault(x => x.IsActive && x.TestHeaderId == testId);
        }

        public LoadAndSterss GetByPk(int testId)
        {
            return _SMContext.LoadAndStersses.Find(testId);
        }

        public void UpdateloadAndSterss(LoadAndSterss test, ClaimsPrincipal user)
        {
            test.IsActive = true;
            test.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            test.DateModified = DateTime.Now;

            _SMContext.Update(test);
            _SMContext.SaveChanges();
        }
    }
}
