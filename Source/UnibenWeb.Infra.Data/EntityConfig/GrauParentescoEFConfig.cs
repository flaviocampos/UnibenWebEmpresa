using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    class GrauParentescoEFConfig : EntityTypeConfiguration<GrauParentesco>
    {
        public GrauParentescoEFConfig()
        {
            ToTable("GrausParentesco");
            HasKey(p => p.GrauParentescoId);
        }
    }
}
