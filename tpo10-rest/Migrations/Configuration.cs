namespace tpo10_rest.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole { Name = nameof(Administrator) },
                new IdentityRole { Name = nameof(Doctor) },
                new IdentityRole { Name = nameof(Nurse) },
                new IdentityRole { Name = nameof(Patient) }
            );

            AddOrUpdateApplicationUser(context, "admin@top10.com", "administrator1", nameof(Administrator));

        }

        private void AddOrUpdateApplicationUser(ApplicationDbContext context, string email, string password, string role)
        {

             using (var userStore = new UserStore<ApplicationUser>(context) { AutoSaveChanges = true }) 
             using (var userManager = new UserManager<ApplicationUser>(userStore)) 
             { 
                 var user = userManager.FindByEmail(email); 
                 if (user == null) 
                 { 
                     user = new ApplicationUser(); 
 
                     user.Email = email; 
                     user.UserName = email; 
                     user.EmailConfirmed = true; 
                     user.LockoutEnabled = true; 
 
                     userManager.Create(user, password); 
                     userManager.AddToRole(user.Id, role); 
                 } 
             } 
        }


    }
}
