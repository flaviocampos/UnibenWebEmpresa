using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Application.ViewModels
{
    public class PagarContaParcelaVm
    {
        public PagarContaParcelaVm()
        {

        }

        public int PagarContaParcelaId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal Juros { get; set; }
        public decimal Desconto { get; set; }
        public bool Status { get; set; } // Pago?

    }
}
