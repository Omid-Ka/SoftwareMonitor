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
    public interface ICodeReviewDetailRepository
    {
        void AddCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user);
        List<CodeReviewDetail> GetCodeReviewDetailByCodeId(int codeId);
        CodeReviewDetail GetByPK(int itemId);
        void UpdateCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user);
        List<CodeReviewDetail> GetCodeReviewDetailByProjectIdAndVersionId(int projectId, int version);
    }
}
