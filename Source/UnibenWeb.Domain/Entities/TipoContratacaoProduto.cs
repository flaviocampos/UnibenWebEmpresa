using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("TipoContratacaoProdutos")]
    public class TipoContratacaoProduto
    {
        public TipoContratacaoProduto()
        {
            
        }

        [Key]
        public int TipoContratacaoProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
    }
}