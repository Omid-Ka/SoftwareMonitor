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
    public interface ICodeReviewDetailService
    {
        void AddCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user);
        List<CodeReviewDetailVM> GetCodeReviewDetailByCodeId(int codeId);
        CodeReviewDetail GetByPK(int itemId);
        void UpdateCodeReviewDetail(CodeReviewDetail detail, ClaimsPrincipal user);
    }
}
