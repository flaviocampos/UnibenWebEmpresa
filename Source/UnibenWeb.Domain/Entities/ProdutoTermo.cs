using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("ProdutoTermos")]
    public class ProdutoTermo
    {
        public ProdutoTermo()
        {
            
        }

        [Key]
        public int ProdutoTermoId { get; set; }
        public string UnimedCodigoTermo { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }

        // ======================================|
        // Atributo de Navegaçãcao Entre Objetos |
        // ======================================|
        public virtual Produto Produto { get; set; }
    }
}