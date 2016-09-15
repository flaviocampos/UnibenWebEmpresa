using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    public class IdentityRoleEfConfig : EntityTypeConfiguration<IdentityRole>
    {
        public IdentityRoleEfConfig()
        {
            ToTable("IdentityRoles");
            HasKey(p => p.Id);
        }
    }
}