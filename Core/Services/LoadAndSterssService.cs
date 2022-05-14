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
    public class LoadAndSterssService : ILoadAndSterssService
    {
        private ILoadAndSterssRepository _loadAndSterssRepository;
        private IProjectVersionRepository _projectVersionRepository;

        public LoadAndSterssService(ILoadAndSterssRepository loadAndSterssRepository, IProjectVersionRepository projectVersionRepository)
        {
            _loadAndSterssRepository = loadAndSterssRepository;
            _projectVersionRepository = projectVersionRepository;
        }

        public void AddLoadAndStress(LoadAndSterss loadAndStress, ClaimsPrincipal user)
        {
            _loadAndSterssRepository.AddLoadAndStress(loadAndStress, user);
        }

        public List<CreateLoadOrStrssTest> GetAllVertionByProjectId(int projectId)
        {
            var model = _loadAndSterssRepository.GetByProjectId(projectId).Select(x=> new CreateLoadOrStrssTest()
            {
                AveTime = x.AveTime,
                Deviation = x.Deviation,
                FailRequest = x.FailRequest,
                SuccessRequest = x.SuccessRequest,
                Throughput = x.Throughput,
                TotalRequest = x.TotalRequest,
                HeaderId = x.TestHeaderId,
                Version = _projectVersionRepository.GetByTestHeaderId(x.TestHeaderId)
            }).ToList();

            return model;
        }

        public LoadAndSterss GetByHeaderId(int testId)
        {
            return _loadAndSterssRepository.GetByHeaderId(testId);
        }

        public LoadAndSterss GetByPk(int testId)
        {
           return _loadAndSterssRepository.GetByPk(testId);
        }

        public CreateLoadOrStrssTest GetByProjectIdAndVersionId(int projectId, int version)
        {
            var model = _loadAndSterssRepository.GetByProjectIdAndVersionId(projectId, version);

            return new CreateLoadOrStrssTest()
            {
                AveTime = model.AveTime,
                Deviation = model.Deviation,
                FailRequest = model.FailRequest,
                SuccessRequest = model.SuccessRequest,
                Throughput = model.Throughput,
                TotalRequest = model.TotalRequest,
                HeaderId = model.TestHeaderId
            };
            
        }

        public void UpdateloadAndSterss(LoadAndSterss test, ClaimsPrincipal user)
        {
            _loadAndSterssRepository.UpdateloadAndSterss(test, user);
        }
    }
}
