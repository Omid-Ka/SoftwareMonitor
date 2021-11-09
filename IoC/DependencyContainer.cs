using Core.Interfaces;
using Core.Services;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
