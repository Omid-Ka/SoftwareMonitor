using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Core.Interfaces
{
    public interface IPartnersService
    {
        void AddPartner(Partners item, ClaimsPrincipal user);
        List<PartnerVM> GetAllPartnerVMByProjectId(int projectId);
        List<ShowPartnersVM> GetAllPartnerInProjectByProjectId(int projectId);
    }
}
