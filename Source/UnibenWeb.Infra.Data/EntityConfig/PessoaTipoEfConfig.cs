using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class PessoaTipoEfConfig : EntityTypeConfiguration<PessoaTipo>
    {
        public PessoaTipoEfConfig()
        {
            ToTable("PessoaTipos");
            HasKey(p => p.PessoaTipoId);
        }
    }
}