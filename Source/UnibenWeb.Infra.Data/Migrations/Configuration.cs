using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UnibenWeb.Infra.Data.Context.UnibenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UnibenWeb.Infra.Data.Context.UnibenContext context)
        {
            context.Bancos.AddOrUpdate(b => b.BancoId
                , new Banco() { Nome = "Banco do Brasil" }
                , new Banco() { Nome = "Santander" });
        }
    }
}
