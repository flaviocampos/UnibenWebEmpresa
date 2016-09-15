using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Entities
{
    [Table("Contratos")]
    public class Contrato
    {
        public Contrato()
        {
            Observacoes = new List<Observacao>();
            CheckList = new List<CheckListContrato>();
            //Beneficiarios = new List<Pessoa>();
        }
        [Key]
        public int ContratoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public DateTime DataRequisicaoCancelamento { get; set; }
        public int MotivoCancelamentoId { get; set; } // FK
        public int ContratoOperadoraId { get; set; } // FK -- Nós vamos ter nosso código interno, mas depois a operadora vai fornecer o código dela (de-para), hoje é modalidade e termo, mas vai mudar, pode ser string 30;
        public int ProdutoId { get; set; } // FK
        public bool MigracaoProduto { get; set; } // setar true para contratos cancelados com motivo = troca produto e gerar automaticamente novo contrato
        public int MesUltimoReajuste { get; set; } //    - inteiro;
        public int AnoUltimoReajuste { get; set; } //    - inteiro;
        public int FormaPagamentoId { get; set; } // FK -- Pré e pós, inteiro;
        public int StatusContratoId { get; set; } // FK -- Teremos um domínio de Status (Digitada, aprovada, ativa, cancelada..);
        public decimal PercentualComissao { get; set; } //  0 a X% - Pode ser copiado do Produto, mas pode ter um ajuste, ou não ter comissão em caso de migrações.Favor verificar se há particularidades, para fazermos a regra.
        public bool CobraTaxaInscricao { get; set; } //  boolean - Pode ser copiado do Produto, mas pode ser alterado;
        public bool Ativo { get; set; }

        public virtual Contrato ContratoAnterior { get; set; } // Para fazermos rastreabilidade nas migrações de Planos;
        public virtual ModoPagamento ModoPagamento { get; set; } // quem vai pagar?
        public virtual Pessoa ContratanteOrigem { get; set; } // contratante - empresa atual ou no fuutro pessoa fisica
        public virtual Pessoa Contratante { get; set; } // contratante - t
        public virtual Pessoa Consultor { get; set; }
        public virtual ICollection<Observacao> Observacoes { get; set; }
        public virtual ICollection<Pessoa> Beneficiarios { get; set; } // titular em grau de parentesco // agregados como titulares
        public virtual ICollection<CheckListContrato> CheckList { get; set; } // titular em grau de parentesco // agregados como titulares

        /*
        */

    }
}
