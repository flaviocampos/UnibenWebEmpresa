using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Domain.Validation.Pessoas;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaReadOnlyRepository _pessoaReadOnlyRepository;

        public PessoaService(IPessoaRepository pessoaRepository,
            IPessoaReadOnlyRepository pessoaReadOnlyRepository)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaReadOnlyRepository = pessoaReadOnlyRepository;
        }

        public ValidationResult Adicionar(Entities.Pessoa pessoa)
        {
            var resultValidacao = new ValidationResult();
            if (!pessoa.IsValid())
            {
                resultValidacao.AdicionarErro(pessoa.ResultadoValidacao);
                return resultValidacao;
            }

            // pessoa menor de idade, cpf invalido, etc...
            var fiscal = new PessoaAptaParaEntrarNoSistema(_pessoaRepository);
            var validacaoService = fiscal.Validar(pessoa);
            if (!validacaoService.IsValid)
            {
                resultValidacao.AdicionarErro(validacaoService);
                return resultValidacao;
            }

            //adicionar
            _pessoaRepository.Add(pessoa);
            return resultValidacao;

        }

        public Entities.Pessoa BuscaPorId(int id)
        {
            return _pessoaReadOnlyRepository.BuscaPorId(id);
        }

        public Entities.Pessoa BuscaPorCPF(string cpf)
        {
            return _pessoaReadOnlyRepository.BuscaPorCPF(cpf);
        }

        public IEnumerable<Entities.Pessoa> BuscaTodos(int skip, int take)
        {
            return _pessoaReadOnlyRepository.BuscaTodos();
        }

        public void Atualizar(Entities.Pessoa pessoa)
        {
            _pessoaRepository.Update(pessoa);
        }

        public void Remover(Entities.Pessoa pessoa)
        {
            _pessoaRepository.Remove(pessoa);
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
