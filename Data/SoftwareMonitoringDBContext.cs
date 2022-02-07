using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Access;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Projects;
using Domain.Models.ProjectTests;
using Domain.Models.Teams;

namespace Data
{
    public class SoftwareMonitoringDBContext : DbContext
    {
        public SoftwareMonitoringDBContext(DbContextOptions<SoftwareMonitoringDBContext> options):base(options)
        {

        }

        public DbSet<Project> Projects { set; get; }
        public DbSet<Lookup> Lookups { set; get; }
        public DbSet<Users> Users { set; get; }
        public DbSet<UserLog> UserLogs { set; get; }
        public DbSet<Partners> Partners { set; get; }
        public DbSet<Team> Teams { set; get; }
        public DbSet<TeamDetail> TeamDetails { set; get; }
        public DbSet<TestHeader> TestHeaders { set; get; }
        public DbSet<DocReview> DocReviews { set; get; }
        public DbSet<CodeReview> CodeReviews { set; get; }
        public DbSet<CodeReviewDetail> CodeReviewDetails { set; get; }
        public DbSet<LoadAndSterss> LoadAndStersses { set; get; }
        public DbSet<Access> Accesses { set; get; }
        public DbSet<AccessGroup> AccessGroups { set; get; }
        public DbSet<AccessGroupDetail> AccessGroupDetails { set; get; }
        public DbSet<UserAccess> UserAccesses { set; get; }
        public DbSet<ProjectUsersRelation> ProjectUsersRelations { set; get; }
        public DbSet<Attachment> Attachment { set; get; }
        public DbSet<ProjectVersion> ProjectVersion { set; get; }
        public DbSet<ProjectComment> ProjectComment { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<SelectedAccess> SelectedAccess { set; get; }

    }
}
