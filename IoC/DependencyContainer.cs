using Core.Interfaces;
using Core.Services;
using Data.Repository;
using Domain.Interfaces;
using EmailService.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EmailService.Repository;

namespace IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IProjectService, ProjectServices>();
            service.AddScoped<IProjectRepository, ProjectRepository>();


            service.AddScoped<ILookupService, LookupServices>();
            service.AddScoped<ILookupRepository, LookupRepository>();


            service.AddScoped<IUsersService, UsersServices>();
            service.AddScoped<IUsersRepository, UsersRepository>();


            service.AddScoped<IPartnersService, PartnersService>();
            service.AddScoped<IPartnersRepository, PartnersRepository>();


            service.AddScoped<IUserLogService, UserLogServices>();
            service.AddScoped<IUserLogRepository, UserLogRepository>();


            service.AddScoped<ITeamService, TeamService>();
            service.AddScoped<ITeamRepository, TeamRepository>();


            service.AddScoped<ITeamDetailService, TeamDetailService>();
            service.AddScoped<ITeamDetailRepository, TeamDetailRepository>();


            service.AddScoped<IAccessService, AccessService>();
            service.AddScoped<IAccessRepository, AccessRepository>();


            service.AddScoped<IAccessGroupService, AccessGroupService>();
            service.AddScoped<IAccessGroupRepository, AccessGroupRepository>();


            service.AddScoped<IAccessGroupDetailService, AccessGroupDetailService>();
            service.AddScoped<IAccessGroupDetailRepository, AccessGroupDetailRepository>();


            service.AddScoped<IUserAccessService, UserAccessService>();
            service.AddScoped<IUserAccessRepository, UserAccessRepository>();


            service.AddScoped<IProjectUsersRelationService, ProjectUsersRelationService>();
            service.AddScoped<IProjectUsersRelationRepository, ProjectUsersRelationRepository>();


            service.AddScoped<ITestHeaderService, TestHeaderService>();
            service.AddScoped<ITestHeaderRepository, TestHeaderRepository>();


            service.AddScoped<ICodeReviewService, CodeReviewService>();
            service.AddScoped<ICodeReviewRepository, CodeReviewRepository>();


            service.AddScoped<ICodeReviewDetailService, CodeReviewDetailService>();
            service.AddScoped<ICodeReviewDetailRepository, CodeReviewDetailRepository>();


            service.AddScoped<IDocReviewService, DocReviewService>();
            service.AddScoped<IDocReviewRepository, DocReviewRepository>();


            service.AddScoped<ILoadAndSterssService, LoadAndSterssService>();
            service.AddScoped<ILoadAndSterssRepository, LoadAndSterssRepository>();


            service.AddScoped<IAttachmentService, AttachmentService>();
            service.AddScoped<IAttachmentRepository, AttachmentRepository>();


            service.AddScoped<IProjectVersionService, ProjectVersionService>();
            service.AddScoped<IProjectVersionRepository, ProjectVersionRepository>();


            service.AddScoped<IProjectCommentService, ProjectCommentService>();
            service.AddScoped<IProjectCommentRepository, ProjectCommentRepository>();


            service.AddScoped<INotificationService, NotificationService>();
            service.AddScoped<INotificationRepository, NotificationRepository>();


            service.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
