using System;
using UnibenWeb.Domain.Interfaces.Specification;
using UnibenWeb.Domain.Validation;

namespace UnibenWeb.Domain.Specification.Pessoa
{
    public class PessoaMenorIdade : ISpecification<Entities.Pessoa>
    {
        public bool IsSatisfiedBy(Entities.Pessoa pessoa)
        {
            return(DateTime.Now.Year - pessoa.DataNascimento.Year > 18) ||
                 (DateTime.Now.Year - pessoa.DataNascimento.Year == 18 
                 && DateTime.Now.Month >= pessoa.DataNascimento.Month);
                 

                //((pessoa.DataNascimento - DateTime.Now).Days >= 0);
        }
    }
}