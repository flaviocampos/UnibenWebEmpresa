using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    class TelContatoEFConfig : EntityTypeConfiguration<TelContato>
    {
        public TelContatoEFConfig()
        {
            ToTable("TelContatos");
            HasKey(p => p.TelContatoId);
        }
    }
}
