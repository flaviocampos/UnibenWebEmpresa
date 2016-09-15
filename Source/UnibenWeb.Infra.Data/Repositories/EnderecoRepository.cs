using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;

namespace UnibenWeb.Infra.Data.Repositories
{
    public class EnderecoRepository: BaseRepository<Endereco>, IEnderecoRepository
    {
        public override void Add(Endereco endereco)
        {
            base.Add(endereco);
        }
    }
}
