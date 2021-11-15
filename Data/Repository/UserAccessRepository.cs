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
    public class UserAccessRepository : IUserAccessRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public UserAccessRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        public IEnumerable<UserAccess> GetAllAccessByUserId(int userId)
        {
            return _SMContext.UserAccesses.Where(x => x.IsActive && x.UserId == userId);
        }

        public void DeleteAccess(UserAccess item, ClaimsPrincipal user)
        {
            item.IsActive = false;
            item.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            item.DateModified = DateTime.Now;

            _SMContext.Update(item);
            _SMContext.SaveChanges();
        }

        public void AddNewAccess(int id, int userid, ClaimsPrincipal user)
        {
            var model = new UserAccess();
            model.UserId = userid;
            model.AccessId = id;
            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }
    }
}
