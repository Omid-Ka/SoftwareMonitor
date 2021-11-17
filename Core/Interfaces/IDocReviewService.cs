using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.ProjectTests;

namespace Core.Interfaces
{
    public interface IDocReviewService
    {
        void AdddocReview(DocReview detail, ClaimsPrincipal user);
        List<DocReviewVM> GetDocReviewsByDocId(int docId);
        void UpdatedocReview(DocReview item, ClaimsPrincipal user);
    }
}
