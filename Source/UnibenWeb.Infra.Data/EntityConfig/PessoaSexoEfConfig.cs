using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class PessoaSexoEfConfig : EntityTypeConfiguration<PessoaSexo>
    {
        public PessoaSexoEfConfig()
        {
            ToTable("PessoaSexos");
            HasKey(p => p.PessoaSexoId);
        }
    }
}