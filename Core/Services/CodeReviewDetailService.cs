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
    public class CodeReviewDetailService : ICodeReviewDetailService
    {
        private ICodeReviewDetailRepository _codeReviewDetailRepository;
        private ILookupRepository _lookupRepository;

        public CodeReviewDetailService(ICodeReviewDetailRepository codeReviewDetailRepository, ILookupRepository lookupRepository)
        {
            _codeReviewDetailRepository = codeReviewDetailRepository;
            _lookupRepository = lookupRepository;
        }

        public void AddCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user)
        {
            _codeReviewDetailRepository.AddCodeReviewDetail(detail, user);
        }
        public List<CodeReviewDetailVM> GetCodeReviewDetailByCodeId(int codeId)
        {
            return _codeReviewDetailRepository.GetCodeReviewDetailByCodeId(codeId).Select(x=>new CodeReviewDetailVM()
            {
                Id = x.Id,
                Description = x.Description,
                DetailType = x.DetailType,
                IndicatorId = x.IndicatorId,
                CodeReviewId = x.CodeReviewId,
                Score = x.Score,
                IndicatorDesc = x.IndicatorId.HasValue ? _lookupRepository.GetByLookupId(x.IndicatorId.Value).Description : ""

            }).ToList();
        }

        public CodeReviewDetail GetByPK(int itemId)
        {
            return _codeReviewDetailRepository.GetByPK(itemId);
        }

        public void UpdateCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user)
        {
            _codeReviewDetailRepository.UpdateCodeReviewDetail(detail, user);
        }

        public List<CodeReviewDetailVM> GetCodeReviewDetailByProjectIdAndVersionId(int projectId, int version)
        {
            return _codeReviewDetailRepository.GetCodeReviewDetailByProjectIdAndVersionId(projectId, version).Select(x=> new CodeReviewDetailVM ()
            {
                CodeReviewId = x.CodeReviewId,
                Description = x.Description,
                DetailType = x.DetailType,
                Id = x.Id,
                Score = x.Score
            }).ToList();
        }

        public List<CodeReviewDetailVM> GetCodeReviewDetailByTestHeaderId(int id)
        {
            return _codeReviewDetailRepository.GetCodeReviewDetailByCodeId(id).Select(x=>new CodeReviewDetailVM()
            {
                DetailType = x.DetailType,
                Score = x.Score,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }
    }
}
