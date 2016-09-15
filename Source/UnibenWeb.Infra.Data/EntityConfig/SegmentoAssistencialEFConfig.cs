using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    class SegmentoAssistencialEFConfig : EntityTypeConfiguration<SegmentoAssistencial>
    {
        public SegmentoAssistencialEFConfig()
        {
            ToTable("SegmentosAssistenciais");
            HasKey(p => p.SegmentoAssistencialId);
        }
    }
}
