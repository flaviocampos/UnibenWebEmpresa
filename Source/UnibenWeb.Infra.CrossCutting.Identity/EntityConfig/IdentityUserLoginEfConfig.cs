using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;


    public class IdentityUserLoginEfConfig : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginEfConfig()
        {
            ToTable("IdentityUserLogins");
            HasKey(p => p.UserId);
        }
    }
