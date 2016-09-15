using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("PessoaTipos")]
    public class PessoaTipo
    {
        public PessoaTipo()
        {
           // Pessoas = new List<Pessoa>();
        }

        public enum EnumTipoPessoa
        {
            // Pessoa Jurídica
            PessoaJurídica = 10,
            Operadora = 11,
            Empresa = 12,
            Instituição = 13,
            Associação = 14,
            Fornecedor = 15,
            // Pessoa Física
            PessoaFísica = 20,
            Beneficiário = 21,
            Titular = 22,
            Dependente = 23,
            BeneficiárioCadastroIncompleto = 24

        }

        [Key]
        public int PessoaTipoId { get; set; }
        public EnumTipoPessoa Tipo { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }

        //public virtual ICollection<Pessoa> Pessoas { get; set; }

    }
}