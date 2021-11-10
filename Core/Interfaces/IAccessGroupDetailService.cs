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
    public interface IAccessGroupDetailService
    {
        void AddGroupDetail(AccessGroupDetail accessGroupDetail, ClaimsPrincipal user);
        void DisableAllAccessByGroupId(int AccessGroupId, ClaimsPrincipal user);
        List<AccessGroupDetail> GetAllDetailByGroupId(int id);
        bool UserHasAccess(int id, int userId);
    }
}
