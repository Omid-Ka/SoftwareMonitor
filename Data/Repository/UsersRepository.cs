using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public UsersRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _SMContext.Users.Where(x=>x.IsActive);
        }

        public Users GetUserForLogin(string Username)
        {
            return _SMContext.Users.SingleOrDefault(x => x.UserName == Username  && x.IsActive);
        }

        public bool HasUserWithUserName(string userName)
        {
            return _SMContext.Users.Any(x => x.UserName.ToLower() == userName.ToLower() && x.IsActive);
        }
        public bool HasUserWithNationalcode(string nationalCode)
        {
            return _SMContext.Users.Any(x => x.NationalCode.ToLower() == nationalCode.ToLower() && x.IsActive);
        }

        public bool HasUserWithPersonnelCode(int? personnelCode)
        {
            return _SMContext.Users.Any(x => x.PersonnelCode == personnelCode && x.IsActive);
        }

        public void AddUser(Users model, ClaimsPrincipal user)
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

        public void DeleteUser(int userId, ClaimsPrincipal user)
        {
            var model = _SMContext.Users.Find(userId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
            //    .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public Users GetUserById(int userId)
        {
            return _SMContext.Users.Find(userId);
        }

        public void EditUser(Users model, ClaimsPrincipal user)
        {

            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public bool IsDisable(ClaimsPrincipal user)
        {
            var UserId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());


            return _SMContext.Users.Any(x => x.IsActive == false && x.Id == UserId);
        }

        public string GetFullNameById(int UserId)
        {
            var data = _SMContext.Users.Find(UserId);


            return data.Name + " " + data.Family;
        }
    }
}
