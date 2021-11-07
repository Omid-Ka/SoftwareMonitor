using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Projects;

namespace Core.Services
{
    public class PartnersService : IPartnersService
    {
        private IPartnersRepository _partnersRepository;

        public PartnersService(IPartnersRepository partnersRepository)
        {
            _partnersRepository = partnersRepository;
        }

        public void AddPartner(Partners item, ClaimsPrincipal user)
        {
            _partnersRepository.AddPartner(item, user);
        }

        public List<PartnerVM> GetAllPartnerVMByProjectId(int projectId)
        {
            return _partnersRepository.GetAllPartnerVMByProjectId(projectId).Select(x=>new PartnerVM()
            {
                UserId = x.UserId,
                TeamId = x.TeamId,
                Id = x.Id
                ,PartnerTeam = x.PartnerTeam ,
                ProjectId = x.ProjectId
            }).ToList();
        }
    }
}
