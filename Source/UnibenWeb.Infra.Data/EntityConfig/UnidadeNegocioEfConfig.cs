﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class UnidadeNegocioEfConfig : EntityTypeConfiguration<UnidadeNegocio>
    {
        public UnidadeNegocioEfConfig()
        {
            ToTable("UnidadesNegocio");
            HasKey(p => p.UnidadeNegocioId);
            Ignore(c => c.ResultadoValidacao);
        }
    }
}
