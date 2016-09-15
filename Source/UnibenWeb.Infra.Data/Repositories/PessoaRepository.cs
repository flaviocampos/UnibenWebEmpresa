using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;

namespace UnibenWeb.Infra.Data.Repositories
{
    public class PessoaRepository: BaseRepository<Pessoa>, IPessoaRepository
    {
        public Pessoa BuscaPorCPF(string cpf)
        {
            return SearchWhere(c => c.CPF_CNPJ == cpf).FirstOrDefault();
        }

        /*
        Para maior segurança de transação, validar erros no commit (SaveChanges);
        O begintransaction do uow é para todo contexto. Utilizar o uow
        public override void Add(Pessoa pessoa)
        {
            Context.Database.BeginTransaction();
            Context.Pessoas.Add(pessoa);
            Context.SaveChanges();
        }
        */

    }
}
