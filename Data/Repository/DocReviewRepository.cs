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
    public class DocReviewRepository : IDocReviewRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public DocReviewRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AdddocReview(DocReview detail, ClaimsPrincipal user)
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
        public IEnumerable<DocReview> GetDocReviewsByDocId(int docId)
        {
            return _SMContext.DocReviews.Where(x => x.IsActive && x.TestHeaderId == docId);
        }

        public void UpdatedocReview(DocReview item, ClaimsPrincipal user)
        {
            var model = _SMContext.DocReviews.Find(item.Id);
            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            model.Description = item.Description;
            model.DocReviewAnswer = item.DocReviewAnswer;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public void DeleteItemsByDocId(int docId, ClaimsPrincipal user)
        {

            var UserId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            var Items = _SMContext.DocReviews.Where(x => x.IsActive && x.TestHeaderId == docId).ToList();
            foreach (var item in Items)
            {
                item.IsActive = false;
                item.UpdatedUser = UserId;
                item.DateModified = DateTime.Now;

                _SMContext.Update(item);
                _SMContext.SaveChanges();

            }


        }

        public string StatusOfCharts(int testId)
        {
            var data = _SMContext.DocReviews.Where(x => x.TestHeaderId == testId);

            if (data.Any(x => x.DocReviewAnswer == DocReviewAnswer.Incomplete) ||
                data.Any(x => x.DocReviewAnswer == DocReviewAnswer.Less))
            {
                return "ناقص";
            }
            else
            {
                return "کامل";
            }

        }
    }
}
