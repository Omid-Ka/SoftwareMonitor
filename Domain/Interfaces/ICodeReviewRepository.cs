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
    public interface ICodeReviewRepository
    {
        void AddCodeReview(CodeReview codeReview, ClaimsPrincipal user);
        void DeleteItemsByCodeId(int codeId, ClaimsPrincipal user);
        CodeReview GetCodeReviewsByHeaderId(int codeId);
        void UpdateCodeReview(CodeReview codeReview, ClaimsPrincipal user);
        CodeReview GetByProjectId(int projectId, int version);
    }
}
