using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities.Identity;

namespace UnibenWeb.Infra.CrossCutting.Identity.EntityConfig
{
    class UserClientEfConfig : EntityTypeConfiguration<UsuarioClient>
    {
        public UserClientEfConfig()
        {
            ToTable("IdentityUserClients");
            HasKey(p => p.Id);
        }
    }
}
