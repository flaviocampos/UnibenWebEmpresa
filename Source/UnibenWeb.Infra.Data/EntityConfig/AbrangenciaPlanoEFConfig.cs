using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class AbrangenciaPlanoEFConfig: EntityTypeConfiguration<AbrangenciaPlano>
    {
        public AbrangenciaPlanoEFConfig()
        {
            ToTable("AbrangenciaPlanos");
            HasKey(p => p.AbrangenciaPlanoId);
        }

    }
}
