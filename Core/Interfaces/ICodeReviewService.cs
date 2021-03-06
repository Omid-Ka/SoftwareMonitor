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
    public interface ICodeReviewService
    {   
        void AddCodeReview(CodeReview codeReview, ClaimsPrincipal user);
        CodeReview GetCodeReviewsByHeaderId(int codeId);
        void UpdateCodeReview(CodeReview codeReview, ClaimsPrincipal user);
        CodeReview GetByProjectId(int projectId, int version);
    }
}
