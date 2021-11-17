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
    public class CodeReviewRepository : ICodeReviewRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public CodeReviewRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddCodeReview(CodeReview codeReview, ClaimsPrincipal user)
        {
            codeReview.IsActive = true;
            codeReview.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            codeReview.DateInserted = DateTime.Now;
            codeReview.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(codeReview);
            _SMContext.SaveChanges();
        }
    }
}
