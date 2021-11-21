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
    public interface ITestHeaderService
    {
        List<TestHeaderVM> GetTestHeaders(TestType TestType, int testId);
        void AddHeader(TestHeader testHeader, ClaimsPrincipal user);
        void DeleteDoc(int docId, ClaimsPrincipal user);
        TestHeader GetByPk(int docId);
        void DeleteCode(int codeId, ClaimsPrincipal user);
        void UpdateHeader(TestHeader testHeader, ClaimsPrincipal user);
        void DeleteStressTest(int testId, ClaimsPrincipal user);
    }
}
