using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Application.Interface;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Infra.Data.Interfaces;

namespace UnibenWeb.Application
{
    public class BaseFbAppService : IBaseFbAppService
    {
        private IUnitOfWork _uow;
        private readonly IBaseFbService _baseFbService;

        public BaseFbAppService(IBaseFbService baseFbService)
        {
            _baseFbService = baseFbService;
        }

        public List<DbDataRecord> Query(string sql)
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            return _baseFbService.Query(sql);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


    }
}
