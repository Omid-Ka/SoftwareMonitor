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
    public class CodeReviewService : ICodeReviewService
    {
        private ICodeReviewRepository _codeReviewRepository;
        private ITestHeaderRepository _testHeaderRepository;

        public CodeReviewService(ICodeReviewRepository codeReviewRepository, ITestHeaderRepository testHeaderRepository)
        {
            _codeReviewRepository = codeReviewRepository;
            _testHeaderRepository = testHeaderRepository;
        }

        public void AddCodeReview(CodeReview codeReview, ClaimsPrincipal user)
        {
            _codeReviewRepository.AddCodeReview(codeReview, user);
        }
        public CodeReview GetCodeReviewsByHeaderId(int codeId)
        {
            return _codeReviewRepository.GetCodeReviewsByHeaderId(codeId);
        }

        public void UpdateCodeReview(CodeReview codeReview, ClaimsPrincipal user)
        {
            _codeReviewRepository.UpdateCodeReview(codeReview, user);
        }

        public CodeReview GetByProjectId(int projectId, int version)
        {
            return _codeReviewRepository.GetByProjectId(projectId,version);
        }
        
    }
}
