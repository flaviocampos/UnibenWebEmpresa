using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        public Produto()
        {

        }

        [Key]
        public int ProdutoId { get; set; }
        public int NumeroRegistro { get; set; }
        public int Sigla { get; set; }
        public int DataRegistro { get; set; }
        public bool AtivoSituacao { get; set; } // ativo ou nao
        // ======================================|
        // Atributo de Navegaçãcao Entre Objetos |
        // ======================================|
        public virtual Pessoa Operadora { get; set; }
        public virtual SegmentoAssistencial SegmentacaoAssistencial { get; set; } 
        public virtual TipoContratacaoProduto TipoContratacao { get; set; } // Adesao, Empresarial
        public virtual AbrangenciaPlano AbrangenciaGeografica { get; set; } // Estadual, nacional...
        public virtual FatorModerador FatorModerador { get; set; } // com ou sem coparticipacao
        public virtual AcomodacaoTipo Acomodacao { get; set; } // Apartamento, enfermaria, a definir
        public virtual ICollection<ProdutoTermo> ProdutoTermos { get; set; } // Coleção de Observações sobre o Produto
        public virtual ICollection<Observacao> Obs { get; set; } // Coleção de Observações sobre o Produto
    }
}
