using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;
using Domain.Models.Account;

namespace Domain.Interfaces
{
    public interface INotificationRepository
    {
        void AddNotification(Notification notification, ClaimsPrincipal user);
        List<Notification> GetAllNotification(int userId);
        void update(Notification item, ClaimsPrincipal user);
    }
}
