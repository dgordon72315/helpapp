namespace HApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<HApp.Models.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HApp.Models.UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("david"))
                WebSecurity.CreateUserAndAccount(
                    "david",
                    "starwars123");
            if (!WebSecurity.UserExists("guest"))
                WebSecurity.CreateUserAndAccount(
                    "david",
                    "starwars123");

            if (!Roles.GetRolesForUser("david").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "david" }, new[] { "Administrator" });
        }
    }
}
