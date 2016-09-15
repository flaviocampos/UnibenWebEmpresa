using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Infra.CrossCutting.Audit.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class LogEFConfig : EntityTypeConfiguration<Audit>
    {
        public LogEFConfig()
        {
            ToTable("Auditorias");
            HasKey(p => p.AuditID);
            Property(p => p.OriginalValue).HasMaxLength(8000);
            Property(p => p.NewValue).HasMaxLength(8000);
            Ignore(p => p.RecordObj);
        }
    }
}