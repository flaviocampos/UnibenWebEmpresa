using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Application.ViewModels
{
    public class BancoVM
    {
        public BancoVM()
        {
                
        }

        /*
        [Required(ErrorMessage = "Preencha o nome da pessoa")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [Required(ErrorMessage = "Preencha o CPF da pessoa")]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Por favor, insira uma data válida no formato dd/mm/yyyy")]
        [ScaffoldColumn(false)]
        [DisplayName("Ativo?")]
        */

        [Key]
        public int BancoId { get; set; }
        public string Nome { get; set; }

    }
}
