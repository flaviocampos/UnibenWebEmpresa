using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IdentityModel.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UnibenWeb.Domain.Entities.Identity;
using UnibenWeb.Application.ViewModels.Identity;
using UnibenWeb.Infra.CrossCutting.Identity.EntityConfig;

namespace UnibenWeb.Infra.CrossCutting.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("UnibenConnection", throwIfV1Schema: false)
        {
        }

        /*

        public DbSet<IdentityUser> AspNetUsers { get; set; }
        */
        public DbSet<UsuarioClient> UsuarioClients { get; set; }
        public DbSet<UsuarioClaim> UsuarioClaims { get; set; }
        public DbSet<IdentityUserClaim> AspNetUserClaims { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //~~~ Precisa comentar o modelBuilder para gerar o scatfold, pois ele não entende.

            modelBuilder.Configurations.Add(new UserClaimEfConfig());
            modelBuilder.Configurations.Add(new UserClientEfConfig());

            //modelBuilder.Entity<IdentityUser>().ToTable("AcessoIdentityUsers");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("AcessoUserClaims");
            //modelBuilder.Configurations.Add(new IdentityUserEfConfig());

            /*
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            */

            /*
            modelBuilder.Entity<IdentityUser>().ToTable("IdentityUsers").Property(p => p.Id).HasColumnName("UsuarioId");
            modelBuilder.Entity<ApplicationUser>().ToTable("IdentityUsers").Property(p => p.Id).HasColumnName("UsuarioId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("IdentityUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IdentityUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IdentityUserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRoles");

            modelBuilder.Configurations.Add(new IdentityUserEfConfig());
            modelBuilder.Configurations.Add(new IdentityRoleEfConfig());
            modelBuilder.Configurations.Add(new IdentityUserRoleEfConfig());
            modelBuilder.Configurations.Add(new IdentityUserClaimEfConfig());
            modelBuilder.Configurations.Add(new IdentityUserLoginEfConfig());
            */

            base.OnModelCreating(modelBuilder);
        }



        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        
    }
}