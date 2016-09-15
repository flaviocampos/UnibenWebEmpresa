using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class OperadoraVm
    {
        public OperadoraVm()
        {
            PessoaTipoId = 2;
        }

        [Key]
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "Preencha a Razão Social")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Razão Social", Description = "Razão Social da Operadora")]
        public string Nome { get; set; }
        [Display(Name = "CNPJ", Description = "Razão Social da Operadora")]
        [Required(ErrorMessage = "Preencha o CNPJ")]
        public string CPF_CNPJ { get; set; }
        [DisplayName("Data de Criação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor, insira uma data válida no formato dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Selecione uma opção válida.")]
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public int BancoId { get; set; }
        public int PessoaTipoId { get; set; }

    }
}