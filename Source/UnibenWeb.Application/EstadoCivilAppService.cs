using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Application
{
    public class EstadoCivilAppService : BaseAppService, IEstadoCivilAppService
    {

        private readonly IEstadoCivilService _estadoCivilService;

        public EstadoCivilAppService(IEstadoCivilService estadoCivilAppService)
        {
            _estadoCivilService = estadoCivilAppService;
        }

        public void Dispose()
        {
            _estadoCivilService.Dispose();
        }

        public IEnumerable<EstadoCivilVM> BuscaTodos(int skip, int take)
        {
            var estadoCivis = _estadoCivilService.BuscaTodos(0, 50);
            return Mapper.Map<IEnumerable<EstadoCivil>, IEnumerable<EstadoCivilVM>>(estadoCivis);
        }

        public SelectList ListasDeSelecao()
        {
            throw new NotImplementedException();
        }
    }
}