using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using UnibenWeb.Application.ViewModels.Identity;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    class IdentityUserEfConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public IdentityUserEfConfig()
        {
            ToTable("IdentityUsers");
            HasKey(p => p.Id);
        }
    }
}
