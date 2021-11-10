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
    public class AccessGroupDetailRepository : IAccessGroupDetailRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public AccessGroupDetailRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public IEnumerable<AccessGroupDetail> GetAllUsedAccess()
        {
            return _SMContext.AccessGroupDetails.Where(x => x.IsActive && x.AccessGroup.IsActive);
        }

        public void AddGroupDetail(AccessGroupDetail model, ClaimsPrincipal user)
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

        public void DeleteAllByGroupId(int GroupId, ClaimsPrincipal user)
        {
            var UserId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            var data = _SMContext.AccessGroupDetails.Where(x => x.IsActive && x.AccessGroupId == GroupId).ToList();

            foreach (var Item in data)
            {
                Item.IsActive = false;
                Item.UpdatedUser = UserId;
                Item.DateModified = DateTime.Now;

                _SMContext.Update(Item);
                _SMContext.SaveChanges();
            }

        }
    }
}
