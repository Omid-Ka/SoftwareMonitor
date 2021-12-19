using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Log;
using Core.Helper;
using Domain.Models.Access;
using Domain.Models.Account;

namespace Data.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private SoftwareMonitoringDBContext _SMContext;

        public NotificationRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public void AddNotification(Notification notification, ClaimsPrincipal user)
        {
            notification.IsActive = true;
            notification.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            notification.DateInserted = DateTime.Now;
            notification.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();

            _SMContext.Add(notification);
            _SMContext.SaveChanges();
        }

        public List<Notification> GetAllNotification(int userId)
        {
            return _SMContext.Notifications.Where(x => x.IsActive && x.Seen == false && x.ReciverUserId == userId)
                .ToList();
        }

        public void update(Notification item, ClaimsPrincipal user)
        {
            item.IsActive = true;
            item.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            item.DateModified = DateTime.Now;

            _SMContext.Update(item);
            _SMContext.SaveChanges();
        }
    }
}
