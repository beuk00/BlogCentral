using BlogCentralApp.Data;
using BlogCentralApp.Hubs;
using BlogCentralApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp
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
            services.AddControllersWithViews();
            //added to run the identityPages(Razor pages)
            services.AddRazorPages();
            services.AddSignalR();

            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration.GetConnectionString("BlogCentralDB")));
            services.AddIdentity<IdentityUser, IdentityRole>(

              options =>
              {
                  options.Password.RequireDigit = false;
                  options.Password.RequiredLength = 3;
                  options.Password.RequireNonAlphanumeric = false;
                  options.Password.RequireUppercase = true;
                  options.Password.RequireLowercase = false;

                  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                  options.Lockout.MaxFailedAccessAttempts = 5;

                  options.User.RequireUniqueEmail = true;
                  options.SignIn.RequireConfirmedEmail = false;

              }
          )
        .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

            services.AddScoped<BlogPostRepository>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<CommentRepository>();
            services.AddScoped<LikeRepository>();

            services.AddScoped<VisitorRepository>();
            services.AddScoped<VisitRepository>();



            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";

                options.Events.OnSigningIn = (context) =>
                {

                    context.CookieOptions.Expires = DateTimeOffset.Now.AddMinutes(5);
                    return Task.CompletedTask;
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                //added to run the identityPages(Razor pages)
                endpoints.MapRazorPages();
                endpoints.MapHub<VisitorsHub>("/chathub");
                endpoints.MapControllerRoute(
                     name: "blogpost comment edit",
                    pattern: "{controller=Home}/{action=Index1}/{blogPostId?}/{commentId?}");
                endpoints.MapControllerRoute(
                    name: "sort",
                    pattern: "{controller=Home}/{action=Index1}/{sort?}/{count?}");
                endpoints.MapControllerRoute(
                     name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index1}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index1}/{id?}");
            });
        }
    }
}
