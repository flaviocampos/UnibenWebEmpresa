using System.Data.Entity.ModelConfiguration;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class ProdutoEfConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoEfConfig()
        {
            ToTable("Produtos");
            HasKey(p => p.ProdutoId);

            // Relacionamento (1) Operadoras (N) Produto            
            HasRequired(prod => prod.Operadora).WithMany().Map(op => op.MapKey("OperadoraId")); //.HasForeignKey(op => op. chave estrangeira?);         
            HasRequired(prod => prod.AbrangenciaGeografica).WithMany().Map(op => op.MapKey("AbrangenciaGeograficaId"));
            HasRequired(prod => prod.Acomodacao).WithMany().Map(op => op.MapKey("AcomodacaoId"));
            HasRequired(prod => prod.FatorModerador).WithMany().Map(op => op.MapKey("FatorModeradorId"));
            HasRequired(prod => prod.SegmentacaoAssistencial).WithMany().Map(op => op.MapKey("SegmentacaoAssistencialId"));
            HasRequired(prod => prod.TipoContratacao).WithMany().Map(op => op.MapKey("TipoContratacaoId"));

            // Relacionamento (N) Termo (1) Produto
            HasMany(prod => prod.ProdutoTermos).WithRequired(termo => termo.Produto).Map(termo=>termo.MapKey("ProdutoId"));

            // Relacionamento (N) Obs (N) Produto
            HasMany(prod => prod.Obs).WithMany().Map(me =>
                {
                    me.MapLeftKey("ProdutoId");
                    me.MapRightKey("ObservacaoId");
                    me.ToTable("ProdutoObservacoes"); // Cria tabela de suporte para relacionamento
                });
        }
    }
}