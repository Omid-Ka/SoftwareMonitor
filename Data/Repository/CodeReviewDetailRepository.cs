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
    public class CodeReviewDetailRepository : ICodeReviewDetailRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public CodeReviewDetailRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user)
        {
            detail.IsActive = true;
            detail.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            detail.DateInserted = DateTime.Now;
            detail.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(detail);
            _SMContext.SaveChanges();
        }
    }
}
