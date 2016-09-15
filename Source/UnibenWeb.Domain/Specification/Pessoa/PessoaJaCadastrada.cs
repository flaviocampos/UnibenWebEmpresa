using System.Linq;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Specification;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    public class PessoaJaCadastrada: ISpecification<Entities.Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaJaCadastrada(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return !_pessoaRepository.SearchWhere(p => p.CPF_CNPJ == pessoa.CPF_CNPJ).Any();
        }
    }
}