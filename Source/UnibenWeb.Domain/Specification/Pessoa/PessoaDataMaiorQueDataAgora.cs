using System;
using UnibenWeb.Domain.Interfaces.Specification;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    class PessoaDataMaiorQueDataAgora : ISpecification<Entities.Pessoa>
    {
        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return (pessoa.DataNascimento < DateTime.Now);
            //((pessoa.DataNascimento - DateTime.Now).Days >= 0);
        }
    }
}
