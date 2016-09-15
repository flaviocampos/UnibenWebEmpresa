using System.Linq;
using UnibenWeb.Domain.Interfaces.Specification;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    class PessoaPossuiEndereco : ISpecification<Entities.Pessoa>
    {
        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return pessoa.Enderecos != null && pessoa.Enderecos.Any();
        }
    }
}
