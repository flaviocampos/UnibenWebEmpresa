using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Specification;

namespace UnibenWeb.Domain.Specification.ContasPagar
{
    class ContasPagarRegraNegocio1 : ISpecification<PagarConta>
    {
        private readonly IPagarContaRepository _pagarContaRepository;

        public ContasPagarRegraNegocio1(IPagarContaRepository pagarContaRepository)
        {
            _pagarContaRepository = pagarContaRepository;
        }

        public bool IsSatisfiedBy(PagarConta entity)
        {
            return true;
        }

    }
}