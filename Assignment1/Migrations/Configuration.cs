namespace Assignment1.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Assignment1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }


            ApplicationUser adminUser = null;

            if (!context.Users.Any(p => p.UserName == "admin@assignments.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.UserName = "admin@assignments.com";
                adminUser.Email = "admin@assignments.com";
                userManager.Create(adminUser, "Security:99");
            }
            else
            {
                adminUser = context.Users.Where(p => p.UserName == "admin@assignments.com").FirstOrDefault();
            }


            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }

        }
    }
}