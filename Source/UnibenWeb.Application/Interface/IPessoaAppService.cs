using System;
using System.Collections.Generic;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface IPessoaAppService: IDisposable
    {
        ValidationAppResult Adicionar(bool doLog, string userId, PessoaEnderecoVM pessoa);
        ValidationAppResult Adicionar(bool doLog, string userId, OperadoraVm operadora);
        PessoaVM BuscaPorId(int id);
        PessoaVM BuscaPorCPF(string cpf);
        IEnumerable<PessoaVM> BuscaTodos(int skip, int take);
        void Atualizar(bool doLog, string userId, PessoaVM pessoa);
        void Remover(bool doLog, string userId, PessoaVM pessoa);
    }
}
