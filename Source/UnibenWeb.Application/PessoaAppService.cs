using AutoMapper;
using System.Collections.Generic;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Application
{
    public class PessoaAppService : BaseAppService, IPessoaAppService
    {
        //private readonly PessoaRepository _pessoaRepository = new PessoaRepository();
        //private readonly PessoaReadOnlyRepository _pessoaReadOnlyRepository = new PessoaReadOnlyRepository();

        private readonly IPessoaService _pessoaService;
        private readonly IBaseService _baseService;

        public PessoaAppService(IPessoaService pessoaService, IBaseService baseService)
        {
            _pessoaService = pessoaService;
            _baseService = baseService;
        }

        public ValidationAppResult Adicionar(bool doLog, string userId, PessoaEnderecoVM pessoaEndVm)
        {
            var pessoa = Mapper.Map<PessoaEnderecoVM, Pessoa>(pessoaEndVm);
            var endereco = Mapper.Map<PessoaEnderecoVM, Endereco>(pessoaEndVm);
            pessoa.Enderecos.Add(endereco);
            pessoa.Ativo = true;
            BeginTransaction();
            var result = _pessoaService.Adicionar(pessoa);
            if (!result.IsValid) { return DomainToApllicationResult(result); }
            Commit(doLog, userId);
            pessoaEndVm.PessoaId = pessoa.PessoaId;
            return DomainToApllicationResult(result);
        }

        public ValidationAppResult Adicionar(bool doLog, string userId, OperadoraVm operadora)
        {
            var pessoa = Mapper.Map<OperadoraVm, Pessoa>(operadora);
            //pessoa.PessoaTipo = new PessoaTipo { PessoaTipoId = operadora.PessoaTipoId };
            //pessoa.Banco = new Banco { BancoId = operadora.BancoId 
            pessoa.Ativo = true;
            BeginTransaction();
            var result = _pessoaService.Adicionar(pessoa);
            if (!result.IsValid) { return DomainToApllicationResult(result); }
            Commit(doLog, userId);
            operadora.PessoaId = pessoa.PessoaId;
            return DomainToApllicationResult(result);
        }

        public void Atualizar(bool doLog, string userId, PessoaVM pessoaVm)
        {
            var pessoa = Mapper.Map<PessoaVM, Pessoa>(pessoaVm);
            BeginTransaction();
            _pessoaService.Atualizar(pessoa);
            Commit(doLog, userId);
        }

        public PessoaVM BuscaPorCPF(string cpf)
        {
            return Mapper.Map<Pessoa, PessoaVM>(_pessoaService.BuscaPorCPF(cpf));
        }

        public PessoaVM BuscaPorId(int id)
        {
            var pessoas = _pessoaService.BuscaPorId(id);
            return Mapper.Map<Pessoa, PessoaVM>(pessoas);
        }

        public IEnumerable<PessoaVM> BuscaTodos(int skip, int take)
        {
            var pessoas = _pessoaService.BuscaTodos(skip, take);
            return Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaVM>>(pessoas);
            //return Mapper.Map<IEnumerable<Pessoa>, IEnumerable<PessoaVM>>(_pessoaRepository.GetAll(skip,take));
        }

        public void Dispose()
        {
            _pessoaService.Dispose();
        }

        public void Remover(bool doLog, string userId, PessoaVM pessoaVm)
        {
            var pessoa = Mapper.Map<PessoaVM, Pessoa>(pessoaVm);
            BeginTransaction();
            _pessoaService.Remover(pessoa);
            Commit(doLog, userId);
        }


    }
}
