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
    public interface ILoadAndSterssService
    {
        void AddLoadAndStress(LoadAndSterss loadAndStress, ClaimsPrincipal user);
        LoadAndSterss GetByHeaderId(int testId);
        LoadAndSterss GetByPk(int testId);
        void UpdateloadAndSterss(LoadAndSterss test, ClaimsPrincipal user);
        CreateLoadOrStrssTest GetByProjectIdAndVersionId(int projectId, int version);
        List<CreateLoadOrStrssTest> GetAllVertionByProjectId(int projectId);
    }
}
