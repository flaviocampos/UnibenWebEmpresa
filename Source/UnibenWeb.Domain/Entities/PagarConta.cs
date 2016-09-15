using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnibenWeb.Domain.Interfaces.Validation;
using UnibenWeb.Domain.Validation.PagarContas;
using ValidationResult = UnibenWeb.Domain.ValueObjects.ValidationResult;

namespace UnibenWeb.Domain.Entities
{
    [Table("PagarContas")]
    public class PagarConta: ISelfValidator
    {
        public PagarConta()
        {
           // contaParcelas = new List<PagarContaParcela>();
        }

        [Key]
        public int PagarContaId{ get; set; }
        public int? FornecedorId { get; set; }
        public int UnidadeNegocioId { get; set; } // uniben parksul, uniben jdiniz
        public int ContaTipoDocumentoId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public int TipoLancamentoId { get; set; } // Nota Fiscal, Conta Luz (fixa) [ mensal, mensal porem agendado termino, lancamento unico ]
        public int ContaContabilId { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataAcolhimentoContaPagar { get; set; }
        public DateTime DataPrevisaoPagamento { get; set; }
        public int NumeroEmissaoFornecedor { get; set; }
        public int NumeroParcelas { get; set; }
        public int? ContaPagarNegociacaoId { get; set; }
        public DateTime? DataNegociacao { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Status { get; set; }

        // ======================================|
        // Atributo de Navegaçãcao Entre Objetos |
        // ======================================|

        public virtual ContaTipoDocumento ContaTipoDocumento { get; set; }
        public virtual Pessoa Fornecedor { get; set; }
        public virtual ContaContabil ContaContabil { get; set; }
        public virtual TipoLancamento TipoLancamento { get; set; }
        public virtual ICollection<CentroCusto> CentrosCusto { get; set; }
        public virtual ICollection<PagarContaParcela> ContaParcelas { get; set; }


        // ===========================================|
        // Validação Dos Dados do Objeto Dessa Classe |
        // ===========================================|
        public ValidationResult ResultadoValidacao { get; set; }
        public bool IsValid()
        {
            var fiscal = new ContaPagarFiscalizarRegras();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
