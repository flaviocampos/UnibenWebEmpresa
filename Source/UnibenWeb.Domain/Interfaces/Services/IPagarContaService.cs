using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IPagarContaService: IDisposable
    {
        ValidationResult Adicionar(PagarConta pagarConta);
        PagarConta BuscarPorId(int id);
        PagarConta BuscarPorId(string path, int id);
        void Atualizar(PagarConta pagarConta);
        void Excluir(PagarConta pagarConta);
        void VincularObjetoContexto(PagarConta pagarConta);
    }
}
