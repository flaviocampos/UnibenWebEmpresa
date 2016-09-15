using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    public class IdentityUserRoleEfConfig : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleEfConfig()
        {
            ToTable("IdentityUserRoles");

            HasKey(p => new {p.UserId, p.RoleId});
        }
    }
}
