using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    public class IdentityUserClaimEfConfig : EntityTypeConfiguration<IdentityUserClaim>
    {
        public IdentityUserClaimEfConfig()
        {
            ToTable("IdentityUserClaims");
            HasKey(p => p.Id);
        }
    }
}