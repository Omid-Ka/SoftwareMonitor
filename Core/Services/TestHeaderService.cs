﻿using Core.DTO;
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
    public class TestHeaderService : ITestHeaderService
    {
        private ITestHeaderRepository _testHeaderRepository;
        private IProjectRepository _projectRepository;
        private ILookupRepository _lookupRepository;
        private IDocReviewRepository _docReviewRepository;
        private ICodeReviewRepository _codeReviewRepository;

        public TestHeaderService(ITestHeaderRepository testHeaderRepository, IProjectRepository projectRepository, ILookupRepository lookupRepository, IDocReviewRepository docReviewRepository, ICodeReviewRepository codeReviewRepository)
        {
            _testHeaderRepository = testHeaderRepository;
            _projectRepository = projectRepository;
            _lookupRepository = lookupRepository;
            _docReviewRepository = docReviewRepository;
            _codeReviewRepository = codeReviewRepository;
        }

        public List<TestHeaderVM> GetTestHeaders(TestType TestType, int testId)
        {
            return _testHeaderRepository.GetTestHeaders(TestType, testId).Select(x=>new TestHeaderVM()
            {
                DateInserted = x.DateInserted,
                EntityId = x.EntityId,
                EntityType = x.EntityType,
                Id = x.Id,
                TestType = x.TestType,
                ProjectName = _projectRepository.GetProjectById(x.Id).ProjectName,
                Title = _lookupRepository.GetByLookupId(x.TitleId).Description

            }).ToList();
        }

        public void AddHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            _testHeaderRepository.AddHeader(testHeader, user);
        }

        public void DeleteDoc(int docId, ClaimsPrincipal user)
        {
            _docReviewRepository.DeleteItemsByDocId(docId, user);
                
            _testHeaderRepository.DeleteDoc(docId,user);
        }

        public TestHeader GetByPk(int docId)
        {
            return _testHeaderRepository.GetByPk(docId);
        }

        public void DeleteCode(int codeId, ClaimsPrincipal user)
        {
            _codeReviewRepository.DeleteItemsByCodeId(codeId, user);
            _testHeaderRepository.DeleteCode(codeId, user);
        }

        public void UpdateHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            _testHeaderRepository.UpdateHeader(testHeader, user);
        }
    }
}
