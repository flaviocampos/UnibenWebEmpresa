using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Interfaces;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Domain.Services
{
    public class BaseFbService : IBaseFbService
    {
        private readonly IBaseFbRepository _baseFbRepository;

        public BaseFbService(IBaseFbRepository baseFbRepository)
        {
            _baseFbRepository = baseFbRepository;
        }

        public List<DbDataRecord> Query(string query)
        {
            return _baseFbRepository.FbQuery(query);
        }

        public void Dispose()
        {
            // dispose repo
        }

    }
}
