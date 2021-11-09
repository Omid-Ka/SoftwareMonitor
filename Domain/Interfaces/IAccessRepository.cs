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
    public interface IAccessRepository
    {
        IEnumerable<Access> GetAllAccess();
        IEnumerable<Access> GetAllCurrentAccessByGroupId(int id);
    }
}
