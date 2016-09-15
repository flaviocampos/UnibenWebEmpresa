using UnibenWeb.Domain.Interfaces.Specification;
using UnibenWeb.Domain.Validation.Documentos;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    class PessoaPossuiCPFValido: ISpecification<Entities.Pessoa>
    {
        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return CPFValidation.Validar(pessoa.CPF_CNPJ);
        }
    }
}
