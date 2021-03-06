using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;

namespace Domain.Interfaces
{
    public interface IUserAccessRepository
    {
        IEnumerable<UserAccess> GetAllAccessByUserId(int userId);
        void DeleteAccess(UserAccess item, ClaimsPrincipal user);
        void AddNewAccess(int id, int userid, ClaimsPrincipal user);
    }
}
