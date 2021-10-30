﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Projects;
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
    }
}