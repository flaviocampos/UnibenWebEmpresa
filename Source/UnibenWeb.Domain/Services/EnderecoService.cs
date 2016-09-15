using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {

        private readonly ICorreiosReadOnlyRepository _correiosReadOnlyRepository;
        private readonly IEnderecoReadOnlyRepository _enderecoReadOnlyRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(ICorreiosReadOnlyRepository correiosReadOnlyRepository
            , IEnderecoReadOnlyRepository enderecoReadOnlyRepository, IEnderecoRepository enderecoRepository)
        {
            _correiosReadOnlyRepository = correiosReadOnlyRepository;
            _enderecoReadOnlyRepository = enderecoReadOnlyRepository;
            _enderecoRepository = enderecoRepository;
        }

        public void Dispose()
        {
            //_correiosReadOnlyRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Endereco BuscaPorId(int id)
        {
           return _correiosReadOnlyRepository.BuscaPorId(id);
        }

        public ValidationResult Adicionar(Endereco endereco)
        {
            // Regras de Negocio
            var resultValidacao = new ValidationResult();
            if (!endereco.IsValid())
            {
                resultValidacao.AdicionarErro(endereco.ResultadoValidacao);
                return resultValidacao;
            }

            // validações de endereco
            /*
            var fiscal = new EnderecoValidoParaEntrarSistema(_enderecoRepositoy);
            var validacaoService = fiscal.Validar(endereco);
            if (!validacaoService.IsValid)
            {
                resultValidacao.AdicionarErro(validacaoService);
                return resultValidacao;
            }
            */

            //adicionar
            _enderecoRepository.Add(endereco);
            return resultValidacao;
        }

        public IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao)
        {
            return _correiosReadOnlyRepository.BuscaComPesquisa(offsetRows, numRows, pesquisaCondicao);
        }

        public IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId)
        {
            return _enderecoReadOnlyRepository.BuscaComPesquisa(offsetRows, numRows, pesquisaCondicao, pessoaId);
        }
    }
}