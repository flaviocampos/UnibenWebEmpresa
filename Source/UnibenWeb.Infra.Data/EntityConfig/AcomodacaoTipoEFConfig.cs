using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class AcomodacaoTipoEFConfig : EntityTypeConfiguration<AcomodacaoTipo>
    {
        public AcomodacaoTipoEFConfig()
        {
            ToTable("AcomodacaoTipos");
            HasKey(p => p.AcomodacaoTipoId);
        }    
    }
}
