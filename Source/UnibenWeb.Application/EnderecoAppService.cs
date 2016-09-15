using System.Collections.Generic;
using AutoMapper;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Application
{
    public class EnderecoAppService: BaseAppService, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public EnderecoVM BuscaPorId(int id)
        {
            var enderecos = _enderecoService.BuscaPorId(id);
            return Mapper.Map<Endereco, EnderecoVM>(enderecos);
        }

        public ValidationAppResult Adicionar(bool doLog, string userId, EnderecoVM endereco)
        {
            var end = Mapper.Map<EnderecoVM, Endereco>(endereco);
            BeginTransaction();
            var result = _enderecoService.Adicionar(end);
            if (!result.IsValid)
            {
                return DomainToApllicationResult(result);
            }
            Commit(doLog,userId);
            endereco.EnderecoId = end.EnderecoId;
            return DomainToApllicationResult(result);
        }

        public IEnumerable<EnderecoVM> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EnderecoVM> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId)
        {
            var enderecos = _enderecoService.BuscaComPesquisa(offsetRows, numRows, pesquisaCondicao, pessoaId);
            return Mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoVM>>(enderecos);
        }

        public void Dispose()
        {
            _enderecoService.Dispose();
        }
    }
}