using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    class ModoPagamentoEFConfig : EntityTypeConfiguration<ModoPagamento>
    {
        public ModoPagamentoEFConfig()
        {
            ToTable("ModosPagamento");
            HasKey(p => p.ModoPagamentoId);
        }
    }
}
