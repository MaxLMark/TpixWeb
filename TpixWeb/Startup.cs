﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpixWeb.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TpixWeb.Models;
using TpixWeb.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TpixWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddUserManager<UserManager<IdentityUser>>();

            services.AddTransient<IRestClient, JsonRestClient>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings altered
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "Content")),
                RequestPath = "/Content"
            });

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "Category",
                //    template: "{controller=Category}/{categoryName}"
                    
                    
                //    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            Task<IdentityResult> roleResult;
            string email = "adminTpix@gmail.com";

            //Check that there is an Administrator role and create if not
            Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Admin");
            hasAdminRole.Wait();

            if (!hasAdminRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Admin"));
                roleResult.Wait();
            }

            //Checks if there is an RegularUser role
            Task<bool> hasRegularRole = roleManager.RoleExistsAsync("Regular");
            hasRegularRole.Wait();

            if (!hasRegularRole.Result)
            {
                roleResult = roleManager.CreateAsync(new IdentityRole("Regular"));
                roleResult.Wait();
            }


            //Check if the admin user exists and create it if not
            //Add to the Administrator role

            Task<IdentityUser> adminUser = userManager.FindByEmailAsync(email);
            adminUser.Wait();

            if (adminUser.Result == null)
            {
                IdentityUser administrator = new IdentityUser();
                administrator.Email = email;
                administrator.UserName = email;

                Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "admin123");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Admin");
                    newUserRole.Wait();
                }
            }

        }
    }
}
