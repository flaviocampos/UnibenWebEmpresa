using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Validation.Base;

namespace UnibenWeb.Domain.Validation.PagarContas
{
    class ContaPagarFiscalizarRegras : FiscalBase<PagarConta>
    {
        public ContaPagarFiscalizarRegras()
        {
            // faz validações dos dados da entidade, inseridos no objeto
        }
    }
}
