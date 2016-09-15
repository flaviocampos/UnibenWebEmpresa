using UnibenWeb.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace UnibenWeb.Infra.Data.EntityConfig
{
    public class EnderecoEFConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoEFConfig()
        {
            HasKey(e=>e.EnderecoId);

            Property(e=>e.Logradouro)
                .IsOptional().HasMaxLength(300);
            Property(e=>e.Numero)
                .IsOptional().HasMaxLength(15);
            Property(e=>e.CEP)
                .IsOptional().HasMaxLength(8);
            Property(e=>e.Complemento)
                .HasMaxLength(300);

            Ignore(c => c.ResultadoValidacao);

            ToTable("Enderecos");

            /*
            HasRequired(p => p.Pessoa)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(e => e.PessoaId);
             */

        }
    }
}
