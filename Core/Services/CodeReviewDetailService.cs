using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.ProjectTests;

namespace Core.Services
{
    public class CodeReviewDetailService : ICodeReviewDetailService
    {
        private ICodeReviewDetailRepository _codeReviewDetailRepository;

        public CodeReviewDetailService(ICodeReviewDetailRepository codeReviewDetailRepository)
        {
            _codeReviewDetailRepository = codeReviewDetailRepository;
        }

        public void AddCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user)
        {
            _codeReviewDetailRepository.AddCodeReviewDetail(detail, user);
        }
    }
}
