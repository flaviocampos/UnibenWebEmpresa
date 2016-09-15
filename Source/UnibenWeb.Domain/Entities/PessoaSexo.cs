using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("PessoaSexos")]
    public class PessoaSexo
    {
        public PessoaSexo()
        {
            
        }

        public enum EnumSexo
        {
            Feminino = 1,
            Masculino = 2
        }
        [Key]
        public int PessoaSexoId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
    }
}