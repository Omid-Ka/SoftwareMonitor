using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _SMContext.Users;
        }

        public Users GetUserForLogin(string Username, string Password)
        {
            return _SMContext.Users.SingleOrDefault(x => x.UserName == Username && x.Password == Password);
        }
    }
}
