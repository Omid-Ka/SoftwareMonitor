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
    public interface ITestHeaderRepository
    {
        List<TestHeader> GetTestHeaders(TestType testType, int testId);
        void AddHeader(TestHeader testHeader, ClaimsPrincipal user);
        //void DeleteDoc(int docId, ClaimsPrincipal user);
        TestHeader GetByPk(int docId);
        //void DeleteCode(int codeId, ClaimsPrincipal user);
        void UpdateHeader(TestHeader testHeader, ClaimsPrincipal user);
        void DeleteHeader(int testId, ClaimsPrincipal user);
        List<TestHeader> GetTestListByProjectId(int projectId);
        List<TestHeader> GetByProjectIdAndVersionId(int projectId, int versionId);
    }
}
