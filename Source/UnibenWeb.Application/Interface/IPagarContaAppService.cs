﻿using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface IPagarContaAppService
    {
        ValidationAppResult Adicionar(bool doLog, string userId, PagarContaVm pagarContaVm);
        PagarContaVm BuscarPorId(int id);
        void Excluir(bool doLog, string userId, PagarContaVm pagarContaVm);
        void Atualizar(bool doLog, string userId, PagarContaVm pagarContaVm);
    }
}
