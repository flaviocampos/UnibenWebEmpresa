using System;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Services
{
    public class PagarContaParcelaService: IPagarContaParcelaService
    {
        private readonly IPagarContaParcelaRepository _pagarContaParcelaRepository;

        public PagarContaParcelaService(IPagarContaParcelaRepository pagarContaParcelaRepository)
        {
            _pagarContaParcelaRepository = pagarContaParcelaRepository;
        }

        public ValidationResult Adicionar(PagarConta pagarConta)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
