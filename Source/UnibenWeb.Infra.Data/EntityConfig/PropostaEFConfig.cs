using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class PropostaEfConfig: EntityTypeConfiguration<Proposta>
    {
        public PropostaEfConfig()
        {
            ToTable("Propostas");
            HasKey(p => p.PropostaId);

            // Relacionamento (1) para (1) 
            HasRequired(p => p.Operadora)
                .WithOptional() 
                .Map(p => p.MapKey("OperadoraId"));

            // Relacionamento (1) para (1) 
            HasRequired(p => p.Produto)
                .WithOptional() 
                .Map(p => p.MapKey("ProdutoId"));

            HasMany(e => e.BeneficiariosProposta)
           .WithMany()
           .Map(me =>
           {
               me.MapLeftKey("PessoaId");
               me.MapRightKey("BeneficiarioId");
               me.ToTable("BeneficiarioProposta"); // Cria tabela de suporte para relacionamento
                });




        }
    }
}