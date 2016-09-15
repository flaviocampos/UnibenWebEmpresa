using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class PessoaTipoVM
    {
        [Key]
        public int PessoaTipoId { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
    }
}