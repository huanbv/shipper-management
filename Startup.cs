using System;
using App.Models;
using App.Repositories.DbContexts;
using App.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            // tải dữ liệu từ appsettings.json
            AddSeedData(services);

            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Local"));
            });

            services.AddMvc().AddXmlSerializerFormatters();

            // driver
            services.AddScoped<IDriverRepo, MockDriverRepo>();

            // shipper
            services.AddScoped<IShipperRepo, MockShipperRepo>();

            // customer
            services.AddScoped<ICustomerRepo, MockCustomerRepo>();

            // consignee
            services.AddScoped<IConsigneeRepo, MockConsigneeRepo>();

            // entry
            services.AddScoped<IEntryRepo, MockEntryRepo>();

            services.AddIdentityCore<Account>(options => {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;

                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<IdentityRole>()
                .AddSignInManager<SignInManager<Account>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();


            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme, options => {
                    options.Cookie.Name = "LoginCookie";
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
            services.AddAuthorization();



            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(0);
            });



            services.AddMvc(opts => opts.EnableEndpointRouting = false);
        }

        private void AddSeedData(IServiceCollection services)
        {
            var adminAccount = Configuration.GetSection("AdminAccount").Get<Account>();
            services.AddSingleton(adminAccount);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: null,
                       template: "",
                       defaults: new {controller = "Account", action = "Index"}
                       );

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}"
                    );
            });


            // thực hiện SeedData --- tạo dữ liệu mẫu
            AppDbContext.SeedData(app.ApplicationServices).Wait();
        }
    }
}
