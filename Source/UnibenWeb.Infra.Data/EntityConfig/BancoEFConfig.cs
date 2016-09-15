﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class BancoEFConfig : EntityTypeConfiguration<Banco>
    {
        public BancoEFConfig()
        {
            HasKey(b => b.BancoId);
            ToTable("Bancos");
        }
    }
}
