using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface ICKContratoService
    {
        ValidationResult Adicionar(CheckListContrato cKContrato);
        CheckListContrato BuscaPorId(int id);
        IEnumerable<CheckListContrato> BuscaTodos(int skip, int take);
        void Atualizar(CheckListContrato cKContrato);
        void Remover(CheckListContrato cKContrato);
    }
}