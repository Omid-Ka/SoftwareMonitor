using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Access;
using Domain.Models.Account;
using System.Security.Principal;
using System.Timers;

namespace Core.Services
{
    public class NotificationService : INotificationService
    {
        private INotificationRepository _notificationRepository;
        private IProjectVersionRepository _projectVersionRepository;
        private IProjectUsersRelationRepository _projectUsersRelationRepository;
        private IProjectRepository _projectRepository;
        private IUsersService _usersService;


        public NotificationService(INotificationRepository notificationRepository, IProjectVersionRepository projectVersionRepository, IProjectUsersRelationRepository projectUsersRelationRepository, IProjectRepository projectRepository, IUsersService usersService)
        {
            _notificationRepository = notificationRepository;
            _projectVersionRepository = projectVersionRepository;
            _projectUsersRelationRepository = projectUsersRelationRepository;
            _projectRepository = projectRepository;
            _usersService = usersService;
        }

        public void AddNotification(int versionId, ClaimsPrincipal user)
        {
            var Project = _projectVersionRepository.GetByPK(versionId);

            var UserProjectIds = _projectUsersRelationRepository.GetAllUserByProjectId(Project.ProjectId);

            var CurrentUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            foreach (var User in UserProjectIds)
            {
                if (CurrentUser != User)
                {
                    var Notification = new Notification()
                    {
                        EntityId = versionId,
                        EntityType = "Version",
                        ReciverUserId = User,
                        Seen = false
                    };

                    _notificationRepository.AddNotification(Notification, user);
                }
            }


        }

        public List<ShowNotification> GetAllNotification(int userId)
        {
            var Notifications = _notificationRepository.GetAllNotification(userId);

            var List = new List<ShowNotification>();

            foreach (var item in Notifications)             
            {
                switch (item.EntityType)
                {
                    case "Project":

                        var TProject = _projectRepository.GetProjectById(item.EntityId.Value);

                        List.Add(new ShowNotification()
                        {
                            Description = "ایجاد نظر جدید در پروژه " + TProject.ProjectName + " توسط " + GetCreator(item.CreatorID) ,
                            EntityId = item.EntityId.HasValue ? item.EntityId.Value : 0 ,
                            EntityType = item.EntityType ,
                            Id = item.Id,
                            Seen = item.Seen,
                            Time = TimeDescription(item.DateInserted)
                        });

                      break;

                    case "Version":

                        var version = _projectVersionRepository.GetByPK(item.EntityId.Value);
                        var Project = _projectRepository.GetProjectById(version.ProjectId);


                        List.Add(new ShowNotification()
                        {
                            Description = "ایجاد نظر جدید در نسخه "+ version.Name + " پروژه " + Project.ProjectName + " توسط " + GetCreator(item.CreatorID),
                            EntityId = item.EntityId.HasValue ? item.EntityId.Value : 0,
                            EntityType = item.EntityType,
                            Id = item.Id,
                            Seen = item.Seen,
                            Time = TimeDescription(item.DateInserted)
                        });

                        break;

                    default:

                        List.Add(new ShowNotification()
                        {
                            Description = "ایجاد نظر جدید در پروژه " + (item.EntityId.HasValue ? _projectRepository.GetProjectById(item.EntityId.Value).ProjectName : ""),
                            EntityId = item.EntityId.HasValue ? item.EntityId.Value : 0,
                            EntityType = item.EntityType,
                            Id = item.Id,
                            Seen = item.Seen,
                            Time = TimeDescription(item.DateInserted)
                        });

                        break;
                }
            }

            return List;
        }
        private string GetCreator(int creatorID)
        {
            return _usersService.GetUserById(creatorID).Family;
        }

        private string TimeDescription(DateTime dateInserted)
        {

            TimeSpan interval = DateTime.Now - dateInserted;

            if(interval.Days > 0)
            {
                return interval.Days + " روز پیش ";
            }

            else if (interval.Hours > 0)
            {
                return interval.Hours + " ساعت پیش ";
            }

            else if (interval.Minutes > 0)
            {
                return interval.Minutes + " دقیقه پیش ";
            }
            else
            {
                return "لحظاتی پیش";
            }



        }



        public void ReadAllProjectVersionNotification(int versionId, ClaimsPrincipal user)
        {
            var version = _projectVersionRepository.GetByPK(versionId);

            var CurrentUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            var notifications = _notificationRepository.GetAllNotification(CurrentUser)
                .Where(x => x.EntityId == versionId ).ToList();

            foreach (var item in notifications)
            {
                item.Seen = true;
                _notificationRepository.update(item, user);
            }

        }


    }
}
