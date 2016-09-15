using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Domain.Services
{
    public class BancoService: IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IBancoReadOnlyRepository _bancoReadOnlyRepository;

        public BancoService(IBancoRepository BancoRepository,
            IBancoReadOnlyRepository BancoReadOnlyRepository)
        {
            _bancoRepository = BancoRepository;
            _bancoReadOnlyRepository = BancoReadOnlyRepository;
        }


        public void Adicionar(Banco banco)
        {
            _bancoRepository.Add(banco);
        }

        public Banco BuscaPorId(int id)
        {
            return _bancoRepository.FindByID(id);
        }

        public IEnumerable<Banco> BuscaTodos(int skip, int take)
        {
            return _bancoReadOnlyRepository.BuscaComPesquisa(skip, take, null);
        }

        public void Atualizar(Banco banco)
        {
            _bancoRepository.Update(banco);
        }

        public void Remover(Banco banco)
        {
            _bancoRepository.Update(banco);
        }

        public void Dispose()
        {
            _bancoRepository.Dispose();
        }
    }
}