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
        private IDocReviewRepository _docReviewRepository;
        private ICodeReviewRepository _codeReviewRepository;
        private ILoadAndSterssRepository _loadAndSterssRepository;
        private IProjectVersionRepository _projectVersionRepository;

        public TestHeaderService(ITestHeaderRepository testHeaderRepository, IProjectRepository projectRepository, ILookupRepository lookupRepository, IDocReviewRepository docReviewRepository, ICodeReviewRepository codeReviewRepository, ILoadAndSterssRepository loadAndSterssRepository, IProjectVersionRepository projectVersionRepository)
        {
            _testHeaderRepository = testHeaderRepository;
            _projectRepository = projectRepository;
            _lookupRepository = lookupRepository;
            _docReviewRepository = docReviewRepository;
            _codeReviewRepository = codeReviewRepository;
            _loadAndSterssRepository = loadAndSterssRepository;
            _projectVersionRepository = projectVersionRepository;
        }

        public List<TestHeaderVM> GetTestHeaders(TestType TestType, int testId)
        {
            var data = _testHeaderRepository.GetTestHeaders(TestType, testId);
            var Result = data.Select(x => new TestHeaderVM()
            {
                DateInserted = x.DateInserted,
                EntityId = x.EntityId,
                EntityType = x.EntityType,
                Id = x.Id,
                TestType = x.TestType,
                ProjectName = (_projectRepository.GetProjectById(x.ProjectId) != null)
                    ? _projectRepository.GetProjectById(x.ProjectId).ProjectName
                    : "",
                Version = x.ProjectVersionId != null && (_projectVersionRepository.GetByPK(x.ProjectVersionId.Value) != null)
                    ? _projectVersionRepository.GetByPK(x.ProjectVersionId.Value).Name
                    : "",

                Title = _lookupRepository.GetByLookupId(x.TitleId).Description,
                StatusOfCharts = _docReviewRepository.StatusOfCharts(x.Id),
                MatchGroups = (_codeReviewRepository.GetCodeReviewsByHeaderId(x.Id) != null)
                    ? _codeReviewRepository.GetCodeReviewsByHeaderId(x.Id).MatchGroups.ToString()
                    : "",
                AllCountRow = (_codeReviewRepository.GetCodeReviewsByHeaderId(x.Id) != null)
                    ? _codeReviewRepository.GetCodeReviewsByHeaderId(x.Id).AllCountRow.ToString()
                    : ""


            });
            return Result.ToList();


        }

        public void AddHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            _testHeaderRepository.AddHeader(testHeader, user);
        }

        public void DeleteDoc(int docId, ClaimsPrincipal user)
        {
            _docReviewRepository.DeleteItemsByDocId(docId, user);

            _testHeaderRepository.DeleteHeader(docId, user);
        }

        public TestHeader GetByPk(int docId)
        {
            return _testHeaderRepository.GetByPk(docId);
        }

        public void DeleteCode(int codeId, ClaimsPrincipal user)
        {
            _codeReviewRepository.DeleteItemsByCodeId(codeId, user);
            _testHeaderRepository.DeleteHeader(codeId, user);
        }

        public void UpdateHeader(TestHeader testHeader, ClaimsPrincipal user)
        {
            _testHeaderRepository.UpdateHeader(testHeader, user);
        }

        public void DeleteStressTest(int testId, ClaimsPrincipal user)
        {
            _loadAndSterssRepository.DeleteStressTest(testId, user);

            _testHeaderRepository.DeleteHeader(testId, user);
        }

        public List<TestHeader> GetTestListByProjectId(int projectId, int version)
        {
            return _testHeaderRepository.GetTestListByProjectId(projectId).Where(x => x.ProjectVersionId == version).ToList();
        }

        public List<TestHeader> GetAllVertionTestListByProjectId(int projectId)
        {
            return _testHeaderRepository.GetTestListByProjectId(projectId).ToList();
        }
    }
}
