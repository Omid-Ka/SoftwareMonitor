using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IProjectUsersRelationService
    {
        bool ChangeUserprojectRelations(int[] vs, int userid, ClaimsPrincipal user);
    }
}
