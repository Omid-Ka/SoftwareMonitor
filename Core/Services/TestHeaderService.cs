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
    public class TestHeaderService : ITestHeaderService
    {
        private ITestHeaderRepository _testHeaderRepository;
        private IProjectRepository _projectRepository;
        private ILookupRepository _lookupRepository;

        public TestHeaderService(ITestHeaderRepository testHeaderRepository, IProjectRepository projectRepository, ILookupRepository lookupRepository)
        {
            _testHeaderRepository = testHeaderRepository;
            _projectRepository = projectRepository;
            _lookupRepository = lookupRepository;
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
    }
}
