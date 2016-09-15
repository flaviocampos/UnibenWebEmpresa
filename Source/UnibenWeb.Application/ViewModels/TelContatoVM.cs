using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class TelContatoVM
    {
        public TelContatoVM()
        {
                
        }
        [Key]
        public int TelContatoId { get; set; }
        public int Descricao { get; set; }
        public int Telefone { get; set; }
        public bool EnviarSMS { get; set; }

        //public Pessoa Pessoa { get; set; }
    }
}