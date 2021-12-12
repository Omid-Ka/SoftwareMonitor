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

        public void DeleteItemsByCodeId(int codeId, ClaimsPrincipal user)
        {
            var UserId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            var Items = _SMContext.CodeReviews.Where(x => x.IsActive && x.TestHeaderId == codeId).ToList();
            foreach (var item in Items)
            {

                var CodeDetail = _SMContext.CodeReviewDetails.Where(x => x.IsActive && x.CodeReviewId == item.Id).ToList();
                foreach (var Detail in CodeDetail)
                {

                    Detail.IsActive = false;
                    Detail.UpdatedUser = UserId;
                    Detail.DateModified = DateTime.Now;

                    _SMContext.CodeReviewDetails.Update(Detail);
                    _SMContext.SaveChanges();
                }


                item.IsActive = false;
                item.UpdatedUser = UserId;
                item.DateModified = DateTime.Now;

                _SMContext.CodeReviews.Update(item);
                _SMContext.SaveChanges();
            }
        }
        public CodeReview GetCodeReviewsByHeaderId(int codeId)
        {
            return _SMContext.CodeReviews.Any(x => x.IsActive && x.TestHeaderId == codeId) ? _SMContext.CodeReviews.FirstOrDefault(x => x.IsActive && x.TestHeaderId == codeId) : new CodeReview();
        }

        public void UpdateCodeReview(CodeReview codeReview, ClaimsPrincipal user)
        {
            codeReview.IsActive = true;
            codeReview.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            codeReview.DateModified = DateTime.Now;


            _SMContext.Update(codeReview);
            _SMContext.SaveChanges();
        }



        public CodeReview GetByProjectId(int projectId, int version)
        {
            var head = _SMContext.TestHeaders
                .Where(x => x.IsActive && x.ProjectId == projectId && x.EntityType == "CodeReview" && x.ProjectVersionId == version)
                .OrderByDescending(x => x.Id).FirstOrDefault();
            if (head != null)
            {
                return _SMContext.CodeReviews.Any(x => x.IsActive && x.TestHeaderId == head.Id) ? _SMContext.CodeReviews.FirstOrDefault(x => x.IsActive && x.TestHeaderId == head.Id) : new CodeReview();
            }
            else
            {
                return new CodeReview();
            }
        }

    }
}
