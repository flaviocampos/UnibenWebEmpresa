using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("Propostas")]
    public class Proposta
    {
        public Proposta()
        {
            //Beneficiarios = new List<Pessoa>();
        }

        [Key]
        public int PropostaId { get; set; }
        public int OperadoraId { get; set; } // FK -- Nós vamos ter nosso código interno, mas depois a operadora vai fornecer o código dela (de-para), hoje é modalidade e termo, mas vai mudar, pode ser string 30;
        public int ProdutoId { get; set; } // FK
        public bool CobraTaxaInscricao { get; set; }
        public bool ContratoEfetuado { get; set; }
        public string MotivoNaoContratacao { get; set; }
        // ======================================|
        // Atributo de Navegaçãcao Entre Objetos |
        // ======================================|
        public virtual Produto Produto { get; set; }
        public virtual Pessoa Operadora { get; set; }
        public virtual ICollection<Pessoa> BeneficiariosProposta { get; set; }
    }
}