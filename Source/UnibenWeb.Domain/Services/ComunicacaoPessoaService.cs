using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Domain.Services
{
    public class ComunicacaoPessoaService : IComunicacaoPessoaService 
    {
        private readonly IComunicacaoPessoaRepository _comunicacaoPessoaRepository;
        public ComunicacaoPessoaService(IComunicacaoPessoaRepository comunicacaoPessoaRepository)
        {
            _comunicacaoPessoaRepository = comunicacaoPessoaRepository;
        }
        public int Adicionar(ComunicacaoPessoa comunicacaoPessoa)
        {
            _comunicacaoPessoaRepository.Add(comunicacaoPessoa);
            return 20; 
        }

        public void Dispose()
        {
            _comunicacaoPessoaRepository.Dispose();
            GC.SuppressFinalize(this);

        }
    }
}
