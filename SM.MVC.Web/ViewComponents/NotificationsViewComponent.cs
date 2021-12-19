using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SM.MVC.Web.ViewComponents
{
    public class NotificationsViewComponent : ViewComponent
    {

        private INotificationService _notificationService;

        public NotificationsViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var UserId = Convert.ToInt32(UserClaimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            var Notifications = _notificationService.GetAllNotification(UserId);
            //ViewBag.Notifications = Notifications;
            ViewBag.CountOfNotifications = Notifications.Count;


            return View("_Notifications", Notifications);
        }

    }
}
