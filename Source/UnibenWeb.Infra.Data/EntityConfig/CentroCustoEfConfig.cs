using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    class CentroCustoEfConfig : EntityTypeConfiguration<CentroCusto>
    {
        public CentroCustoEfConfig()
        {
            ToTable("CentroCustos");
            HasKey(p => p.CentroCustoId);

            Ignore(c => c.ResultadoValidacao);
        }
    }
}
