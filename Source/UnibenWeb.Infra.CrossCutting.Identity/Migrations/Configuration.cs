using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using UnibenWeb.Application.ViewModels.Identity;
using UnibenWeb.Infra.CrossCutting.Identity.Configuration;

namespace UnibenWeb.Infra.CrossCutting.Identity.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<UnibenWeb.Infra.CrossCutting.Identity.Context.IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }




        protected override void Seed(UnibenWeb.Infra.CrossCutting.Identity.Context.IdentityContext context)
        {





















            //ApplicationUserManager userManager;
            //var hash = new PasswordHasher().HashPassword("dlvinfo3738");
            //var userAggregate = UserAggregate.Create("Admin", "", hash, DateTime.Now.ToString());
            //var user = new ApplicationUser { UserName = "uniben.juizdefora@gmail.com", Email = "uniben.juizdefora@gmail.com" };
            //var result = userManager.CreateAsync(user, "dlvinfo3738");
            //UserManager instance like userManager.PasswordHasher=new MyPasswordHasher()

            context.SaveChanges();

            //if (!(context.AcessoIdentityUsers.SqlQuery("select * from AcessoIdentityUsers where UserName = 'dj@dj.com'")))
            // {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { Email = "uniben.juizdefora@gmail.com", UserName = "uniben.juizdefora@gmail.com", PhoneNumber = "22223333" };
            userManager.Create(userToInsert, "dlvinfo3738");

            context.AcessoUserClaims.AddOrUpdate(
                u => u.Id, new IdentityUserClaim()
                {
                    UserId = userToInsert.Id,
                    ClaimType = "Adm",
                    ClaimValue = "1"
                });



        }
    }
}
