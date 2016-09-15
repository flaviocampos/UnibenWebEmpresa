using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Application.ViewModels
{
    public class PessoaEnderecoVM
    {
        public PessoaEnderecoVM()
        {
            //PessoaId = Guid.NewGuid();
            //EnderecoId = Guid.NewGuid();
        }
        /* 
         * Pessoa 
         */
        [Key]
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Preencha o nome da pessoa")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o CPF da pessoa")]
        public string CPF_CNPJ { get; set; }
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor, insira uma data válida no formato dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma opção válida.")]
       // public EnumSexoVM SexoId { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissorId { get; set; } // FK
        public int NaturalidadeId { get; set; } // FK
        public int NacionalidadeId { get; set; } // FK
        public string CartaoSUS { get; set; }
        public string PISPASEP { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public int BancoId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int SexoId { get; set; }
        public int PessoaTipoId { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        /* 
         * Endereço 
         */
        [Key]
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        [DisplayName("Número")]
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
    }
}
