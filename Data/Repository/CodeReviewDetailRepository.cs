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
        public List<CodeReviewDetail> GetCodeReviewDetailByCodeId(int codeId)
        {
            return _SMContext.CodeReviewDetails.Where(x => x.IsActive && x.CodeReviewId == codeId).ToList();
        }

        public CodeReviewDetail GetByPK(int itemId)
        {
            return _SMContext.CodeReviewDetails.Find(itemId);
        }

        public void UpdateCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user)
        {
            detail.IsActive = true;
            detail.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            detail.DateModified = DateTime.Now;


            _SMContext.Update(detail);
            _SMContext.SaveChanges();
        }

        public List<CodeReviewDetail> GetCodeReviewDetailByProjectIdAndVersionId(int projectId, int version)
        {
            var header = _SMContext.TestHeaders
                .FirstOrDefault(x =>x.IsActive && x.ProjectId == projectId && x.ProjectVersionId == version && x.EntityType == "CodeReview");

            var CodeReview = _SMContext.CodeReviews.FirstOrDefault(x => x.IsActive && x.TestHeaderId == header.Id);

            return _SMContext.CodeReviewDetails.Where(x => x.IsActive && x.CodeReviewId == CodeReview.Id).ToList();

        }
    }
}
