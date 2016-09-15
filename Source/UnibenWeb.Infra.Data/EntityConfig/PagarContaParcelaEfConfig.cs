using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class PagarContaParcelaEfConfig : EntityTypeConfiguration<PagarContaParcela>
    {
        public PagarContaParcelaEfConfig()
        {
            ToTable("PagarContaParcelas");
            HasKey(p => p.PagarContaParcelaId);

            Ignore(c => c.ResultadoValidacao);

        }
    }
}
