using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SM.MVC.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using EmailService;
using IoC;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SM.MVC.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            services.AddSingleton(emailConfig);

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("SoftwareMonitorIdentityDBConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<SoftwareMonitoringDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SoftwareMonitoringDBContext"));
            });


            //var server = Configuration["DatabaseServer"] ?? "";
            //var port = Configuration["DatabasePort"] ?? "";
            //var user = Configuration["DatabaseUser"] ?? "";
            //var password = Configuration["DatabasePassword"] ?? "";
            //var database = Configuration["DatabaseName"] ?? "";

            //var connectionString =
            //    $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}";

            //services.AddDbContext<SoftwareMonitoringDBContext>(options =>
            //{
            //    options.UseSqlServer(connectionString, sqlServer => sqlServer.MigrationsAssembly("Sql.API"));
            //});

            services.AddControllersWithViews();
            RegisterServices(services);

            services.AddRazorPages();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Login/Index";
                    option.LogoutPath = "/Login/Logout";
                    option.ExpireTimeSpan = TimeSpan.FromDays(10);
                });

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }


        public static void RegisterServices(IServiceCollection service)
        {
            DependencyContainer.RegisterServices(service);
        }

    }
}
