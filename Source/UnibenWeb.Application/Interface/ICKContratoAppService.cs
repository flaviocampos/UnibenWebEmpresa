using System.Collections.Generic;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface ICKContratoAppService
    {
        ValidationAppResult Adicionar(CheckListContratoVM pessoa);
        CheckListContratoVM BuscaPorId(int id);
        IEnumerable<CheckListContratoVM> BuscaTodos(int skip, int take);
        void Atualizar(CheckListContratoVM pessoa);
        void Remover(CheckListContratoVM pessoa);
    }
}