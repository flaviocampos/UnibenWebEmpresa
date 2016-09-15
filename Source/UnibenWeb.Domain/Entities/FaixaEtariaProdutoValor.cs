using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("FaixaEtariaProdutoValores")]
    public class FaixaEtariaProdutoValor
    {
        public FaixaEtariaProdutoValor()
        {

        }

        [Key]
        public int FaixaEtariaProdutoValorId { get; set; }
        public int ProdutoId { get; set; }
        public int FaixaEtariaInicio { get; set; }
        public int FaixaEtariaFim { get; set; }
        public decimal PercentualAjusteValor { get; set; }
    }
}