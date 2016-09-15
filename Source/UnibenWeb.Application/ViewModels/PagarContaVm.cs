using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class PagarContaVm
    {
        public PagarContaVm()
        {
        }

        [Key]
        public int PagarContaId { get; set; }
        public int? FornecedorId { get; set; }
        public int UnidadeNegocioId { get; set; } // uniben parksul, uniben jdiniz
        public int ContaTipoDocumentoId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }
        public int TipoLancamentoId { get; set; } // Nota Fiscal, Conta Luz (fixa) [ mensal, mensal porem agendado termino, lancamento unico ]
        public int ContaContabilId { get; set; }
        [DisplayName("Data de Emissao (Dia/Mes/Ano)")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida no formato dia/mes/ano")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataEmissao { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida no formato dia/mes/ano")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataAcolhimentoContaPagar { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida no formato dia/mes/ano")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrevisaoPagamento { get; set; }
        public int NumeroEmissaoFornecedor { get; set; } // numero de emissao da fatura / conta / cupom
        public int NumeroParcelas { get; set; }
        public int ContaPagarNegociacaoId { get; set; }
        public DateTime DataNegociacao { get; set; }
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }
        public bool Status { get; set; }

        public IEnumerable<int> CentroCustoId { get; set; } // FK - CentroCustoId -- comercial, impostos, diretoria, cobrança, RH
        public ICollection<CentroCustoVm> CentrosCusto { get; set; } // FK - CentroCustoId -- comercial, impostos, diretoria, cobrança, RH

    }
}
