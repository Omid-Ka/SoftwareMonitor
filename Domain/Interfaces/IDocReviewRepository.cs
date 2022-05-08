using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.ProjectTests;

namespace Domain.Interfaces
{
    public interface IDocReviewRepository
    {
        void AdddocReview(DocReview detail, ClaimsPrincipal user);
        IEnumerable<DocReview> GetDocReviewsByDocId(int docId);
        void UpdatedocReview(DocReview item, ClaimsPrincipal user);
        void DeleteItemsByDocId(int docId, ClaimsPrincipal user);
        string StatusOfCharts(int testId);
    }
}
