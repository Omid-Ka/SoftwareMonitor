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
    public interface IAccessGroupDetailRepository
    {
        IEnumerable<AccessGroupDetail> GetAllUsedAccess();
        void AddGroupDetail(AccessGroupDetail accessGroupDetail, ClaimsPrincipal user);
        void DeleteAllByGroupId(int GroupId, ClaimsPrincipal user);
    }
}
