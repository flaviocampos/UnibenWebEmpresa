using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class ContratoEFConfig : EntityTypeConfiguration<Contrato>
    {
        public ContratoEFConfig()
        {
            HasKey(c => c.ContratoId);

            /*
            Property(p => p.Nome)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();

            Property(p => p.CPF)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11);

            ToTable("Pessoas");

            //Relacionamento (n) para (n)
            HasMany(e => e.Enderecos)
                .WithMany()
                .Map(me => {
                    me.MapLeftKey("PessoaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaEndereco");          // Cria tabela de suporte para relacionamento
                });
            */
        }

    }
}
