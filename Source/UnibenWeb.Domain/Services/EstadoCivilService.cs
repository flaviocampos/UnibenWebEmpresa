using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Domain.Services
{
    public class EstadoCivilService: IEstadoCivilService
    {
        private readonly IEstadoCivilRepository _estadoCivilRepository;
        //private readonly IEstadoCivilReadOnlyRepository _EstadoCivilReadOnlyRepository; -- a criar para adiquirir performance do Dapper

        public EstadoCivilService(IEstadoCivilRepository estadoCivilRepository)
        {
            _estadoCivilRepository = estadoCivilRepository;
        }

        public void Dispose()
        {
            _estadoCivilRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<EstadoCivil> BuscaTodos(int skip, int take)
        {
            return _estadoCivilRepository.GetAll(skip, take);
        }
    }
}
