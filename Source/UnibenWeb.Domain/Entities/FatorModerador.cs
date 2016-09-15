using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("FatorModeradores")]
    public class FatorModerador
    {
        public FatorModerador()
        {
            
        }

        [Key]
        public int FatorModeradorId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }

    }
}