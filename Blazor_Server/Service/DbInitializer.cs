using Blazor_Server.Service.IService;
using Core;
using Core.Common;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Server.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db, ILogger<DbInitializer> Logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = Logger;
        }
        public async Task Initialize()
        {
            try
            {
                if ((await _db.Database.GetPendingMigrationsAsync()).Any())
                {
                    await _db.Database.MigrateAsync();
                    _logger.LogInformation("Migrated");
                }

                if (await _roleManager.RoleExistsAsync(Constants.Role_Admin) == false)
                {
                    await _roleManager.CreateAsync(new IdentityRole(Constants.Role_Admin));
                    await _roleManager.CreateAsync(new IdentityRole(Constants.Role_User));
                    _logger.LogInformation("Roles Created");
                }

                var adminUser = new ApplicationUser()
                {
                    UserName = "admin@x.x",
                    Email = "admin@x.x",
                    FirstName = "system",
                    LastName = "admin",
                };

                if (await _userManager.FindByNameAsync(adminUser.UserName) is null)
                {
                    await _userManager.CreateAsync(adminUser, "1");
                    await _userManager.AddToRoleAsync(adminUser, Constants.Role_Admin);
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error Inializing Db: " + e.Message);
            }
        }
    }
}
