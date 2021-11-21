using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public LoadAndSterssService(ILoadAndSterssRepository loadAndSterssRepository)
        {
            _loadAndSterssRepository = loadAndSterssRepository;
        }

        public void AddLoadAndStress(LoadAndSterss loadAndStress, ClaimsPrincipal user)
        {
            _loadAndSterssRepository.AddLoadAndStress(loadAndStress, user);
        }

        public LoadAndSterss GetByHeaderId(int testId)
        {
            return _loadAndSterssRepository.GetByHeaderId(testId);
        }

        public LoadAndSterss GetByPk(int testId)
        {
           return _loadAndSterssRepository.GetByPk(testId);
        }

        public void UpdateloadAndSterss(LoadAndSterss test, ClaimsPrincipal user)
        {
            _loadAndSterssRepository.UpdateloadAndSterss(test, user);
        }
    }
}
