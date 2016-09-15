using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class EstadoCivilEFConfig : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilEFConfig()
        {
            HasKey(ec => ec.EstadoCivilId);
            ToTable("EstadoCivis");


        }
    }
}
