using UnibenWeb.Domain.Interfaces.Specification;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    class PessoaPossuiStatusAtivo:ISpecification<Entities.Pessoa>
    {
        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return pessoa.Ativo;
        }
    }
}
