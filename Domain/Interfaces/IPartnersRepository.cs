using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Domain.Interfaces
{
    public interface IPartnersRepository
    {
        void AddPartner(Partners item, ClaimsPrincipal user);
        List<Partners> GetAllPartnerVMByProjectId(int projectId);
        IEnumerable<Partners> GetAllTeamsByProjectId(int projectId);
        IEnumerable<Partners> GetAllUsersByProjectId(int projectId);
        void DeletePartnerByPK(int? id, ClaimsPrincipal user);
    }
}
