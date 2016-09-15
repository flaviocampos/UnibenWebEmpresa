using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities.Identity;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    public class UserClaimEfConfig : EntityTypeConfiguration<UsuarioClaim>
    {
        public UserClaimEfConfig()
        {
            ToTable("IdentityClaims");
            HasKey(p => p.Id);
        }

    }
}
