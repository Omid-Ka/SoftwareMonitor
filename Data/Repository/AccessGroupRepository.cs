using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Log;
using Core.Helper;
using Domain.Models.Access;

namespace Data.Repository
{
    public class AccessGroupRepository : IAccessGroupRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public AccessGroupRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public IEnumerable<AccessGroup> GetAllGroups()
        {
            return _SMContext.AccessGroups.Where(x => x.IsActive);
        }

        public bool HasDuplicate(string groupName)
        {
            return _SMContext.AccessGroups.Any(x => x.Name.ToLower().Trim() == groupName.ToLower().Trim());
        }

        public void AddAccessGroup(AccessGroup model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }

        public void DeleteGroup(int id, ClaimsPrincipal user)
        {
            var model = _SMContext.AccessGroups.Find(id);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
            //    .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public AccessGroup GetById(int id)
        {
            return _SMContext.AccessGroups.Find(id);
        }

        public void UpdateAccessGroup(AccessGroup entity, ClaimsPrincipal user)
        {
            entity.IsActive = true;
            entity.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            entity.DateModified = DateTime.Now;

            _SMContext.Update(entity);
            _SMContext.SaveChanges();
        }
    }
}
