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
    public interface IAccessGroupRepository
    {
        IEnumerable<AccessGroup> GetAllGroups();
        bool HasDuplicate(string groupName);
        void AddAccessGroup(AccessGroup entity, ClaimsPrincipal user);
        void DeleteGroup(int id, ClaimsPrincipal user);
        AccessGroup GetById(int id);
        void UpdateAccessGroup(AccessGroup entity, ClaimsPrincipal user);
    }
}
