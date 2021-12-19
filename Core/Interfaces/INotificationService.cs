using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;
using System.Security.Principal;

namespace Core.Interfaces
{
    public interface INotificationService
    {
        void AddNotification(int versionId, ClaimsPrincipal user);
        List<ShowNotification> GetAllNotification(int userId);
        void ReadAllProjectVersionNotification(int versionId, ClaimsPrincipal user);
    }
}
