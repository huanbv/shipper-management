using System;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Repositories.DbContexts
{
    public class AppDbContext : IdentityDbContext<Account>
    {
        #region Driver
        // driver get/set
        public DbSet<Driver> Drivers { get; set; }
        #endregion

        #region Shipper
        // shipper get/set
        public DbSet<Shipper> Shippers { get; set; }
        #endregion

        #region Customer
        // shipper get/set
        public DbSet<Customer> Customers { get; set; }
        #endregion

        #region Consignee
        // consignee get/set
        public DbSet<Consignee> Consignees { get; set; }
        #endregion

        #region Order
        // entry get/set
        public DbSet<Entry> Entries { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }



        public static async Task SeedData(IServiceProvider service)
        {
            if (await SeedRole(service))
            {
                await SeedAdminAccount(service);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        private static async Task<bool> SeedRole(IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any())
            {
                var superAdminResult = await roleManager.CreateAsync(new IdentityRole(Constants.SuperAdminRole));
                var adminResult = await roleManager.CreateAsync(new IdentityRole(Constants.AdminRole));

                return superAdminResult.Succeeded && adminResult.Succeeded;
            }

            return true;
        }


        private static async Task<bool> SeedAdminAccount(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<Account>>();

            // lấy dữ liệu AdminAccount
            var adminAccount = service.GetRequiredService<Account>();
            adminAccount.UserName = adminAccount.Email;


            if (await userManager.FindByEmailAsync(adminAccount.Email) == null) // khi chưa có bất kỳ tài khoản Admin nào
            {
                var createResult = await userManager.CreateAsync(adminAccount, adminAccount.Password);
                if (createResult.Succeeded)
                {
                    var addToRoleResult = await userManager.AddToRoleAsync(adminAccount, Constants.SuperAdminRole);
                    return addToRoleResult.Succeeded;
                }

                return createResult.Succeeded;
            }

            // khi đã có tài khoản Admin
            return true;
        }


    }
}
