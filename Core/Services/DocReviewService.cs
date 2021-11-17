using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.ProjectTests;

namespace Core.Services
{
    public class DocReviewService : IDocReviewService
    {
        private IDocReviewRepository _docReviewRepository;

        public DocReviewService(IDocReviewRepository docReviewRepository)
        {
            _docReviewRepository = docReviewRepository;
        }

        public void AdddocReview(DocReview detail, ClaimsPrincipal user)
        {
            _docReviewRepository.AdddocReview(detail, user);
        }

        public List<DocReviewVM> GetDocReviewsByDocId(int docId)
        {
            return _docReviewRepository.GetDocReviewsByDocId(docId).Select(x=>new DocReviewVM()
            {
                Description = x.Description,
                DocReviewAnswer = x.DocReviewAnswer,
                DocReviewTitle = x.DocReviewTitle,
                Id = x.Id,
            }).ToList();

        }

        public void UpdatedocReview(DocReview item, ClaimsPrincipal user)
        {
            _docReviewRepository.UpdatedocReview(item, user);
        }
    }
}
