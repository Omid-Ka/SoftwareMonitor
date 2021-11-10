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
    public interface IAccessService
    {
        List<AccessVM> GetAllNotUsedAccess();
        List<AccessVM> GetAllCurrentAccessByGroupId(int id);
        List<AccessVM> GetAllByGroupId(int groupId);
        string[] GetAllByIds(int[] accessIds);
    }
}
