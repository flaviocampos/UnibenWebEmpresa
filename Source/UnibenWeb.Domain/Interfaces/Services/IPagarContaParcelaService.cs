using System;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IPagarContaParcelaService: IDisposable
    {
        ValidationResult Adicionar(PagarConta pagarConta);
    }
}
