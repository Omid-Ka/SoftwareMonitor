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

        public void AddHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            testHeader.IsActive = true;
            testHeader.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            testHeader.DateInserted = DateTime.Now;
            testHeader.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();

            _SMContext.Add(testHeader);
            _SMContext.SaveChanges();
        }

        //public void DeleteDoc(int docId, ClaimsPrincipal user)
        //{
        //    var model = _SMContext.DocReviews.Find(docId);
        //    model.IsActive = false;
        //    model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
        //        .FirstOrDefault());
        //    model.DateModified = DateTime.Now;


        //    _SMContext.Update(model);
        //    _SMContext.SaveChanges();
        //}

        public TestHeader GetByPk(int docId)
        {
            return _SMContext.TestHeaders.Find(docId);
        }

        //public void DeleteCode(int codeId, ClaimsPrincipal user)
        //{
        //    var model = _SMContext.CodeReviews.Find(codeId);
        //    model.IsActive = false;
        //    model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
        //        .FirstOrDefault());
        //    model.DateModified = DateTime.Now;


        //    _SMContext.Update(model);
        //    _SMContext.SaveChanges();
        //}

        public void UpdateHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            testHeader.IsActive = true;
            testHeader.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            testHeader.DateModified = DateTime.Now;


            _SMContext.Update(testHeader);
            _SMContext.SaveChanges();
        }

        public void DeleteHeader(int testId, ClaimsPrincipal user)
        {
            var model = _SMContext.TestHeaders.Find(testId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public List<TestHeader> GetTestListByProjectId(int projectId)
        {
            return _SMContext.TestHeaders.Where(x => x.IsActive && x.ProjectId == projectId).ToList();
        }
    }
}
