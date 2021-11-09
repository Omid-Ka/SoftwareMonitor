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
    public interface IAccessGroupService
    {
        IEnumerable<AccessGroup> GetAllGroups();
        bool HasDuplicate(string groupName);
        void AddAccessGroup(AccessGroup entity, ClaimsPrincipal user);
        void DeleteGroup(int id, ClaimsPrincipal user);
        AccessGroup GetById(int id);
        void UpdateAccessGroup(AccessGroup entity, ClaimsPrincipal user);
    }
}
