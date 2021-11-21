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
    public interface ILoadAndSterssRepository
    {
        void AddLoadAndStress(LoadAndSterss loadAndStress, ClaimsPrincipal user);
        void DeleteStressTest(int testId, ClaimsPrincipal user);
        LoadAndSterss GetByHeaderId(int testId);
        LoadAndSterss GetByPk(int testId);
        void UpdateloadAndSterss(LoadAndSterss test, ClaimsPrincipal user);
    }
}
