using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Specification.ContasPagar;
using UnibenWeb.Domain.Validation.Base;

namespace UnibenWeb.Domain.Validation.PagarContas
{
    class RegraNegocioContasPagar : FiscalBase<PagarConta>
    {
        private readonly IPagarContaRepository _pagarContaRepository;

        public RegraNegocioContasPagar(IPagarContaRepository pagarContaRepository)
        {
            _pagarContaRepository = pagarContaRepository;
            var pessoaDuplicada = new ContasPagarRegraNegocio1(_pagarContaRepository);
            base.AdicionarRegra("PessoaDuplicada", new Regra<PagarConta>(pessoaDuplicada, "Já existe o mesmo CPF cadastrado no sistema!"));
        }
    }
}
