using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using Domain.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Data.Repository
{
    public class PartnersRepository : IPartnersRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public PartnersRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddPartner(Partners model, ClaimsPrincipal user)
        {
            var Duplicate = _SMContext.Partners.Any(x =>
                x.IsActive && x.ProjectId == model.ProjectId && (x.TeamId == model.TeamId || x.UserId == model.UserId));

            if (!Duplicate)
            {
                model.IsActive = true;
                model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                    .Select(x => x.Value)
                    .FirstOrDefault());
                model.DateInserted = DateTime.Now;
                model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                    .FirstOrDefault();


                _SMContext.Add(model);
                _SMContext.SaveChanges();
            }
        }

        public List<Partners> GetAllPartnerVMByProjectId(int projectId)
        {
            return _SMContext.Partners.Where(x => x.IsActive && x.ProjectId == projectId).ToList();
        }
    }
}
