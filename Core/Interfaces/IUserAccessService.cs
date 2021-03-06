using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;

namespace Core.Interfaces
{
    public interface IUserAccessService
    {
        IEnumerable<UserAccess> GetAllByUserId(int userid);
        bool ChangeUserAccess(int[] intIds, int userid, ClaimsPrincipal user);
    }
}
