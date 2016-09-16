using Ninject.Modules;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Domain.Services;
using UnibenWeb.Infra.Data.Context;
using UnibenWeb.Infra.Data.Interfaces;
using UnibenWeb.Infra.Data.Repositories;
using UnibenWeb.Infra.Data.Repositories.ReadOnly;
using UnibenWeb.Infra.Data.UoW;

namespace UnibenWeb.Infra.CrossCutting.IoC
{
    public class NinjectModulo: NinjectModule
    {
        public override void Load()
        {
            // Domain Service
            Bind<IBancoService>().To<BancoService>();
            Bind<IBaseService>().To<BaseService>();
            Bind<IBaseFbService>().To<BaseFbService>();

            // Infra.Data
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            Bind<IBaseFbRepository>().To<BaseFbRepository>();
            Bind<IBancoRepository>().To<BancoRepository>();

            // Infra.Data ReadOnly
            Bind<IBancoReadOnlyRepository>().To<BancoReadOnlyRepository>();
            Bind<IBaseReadOnlyRepository>().To<BaseReadOnlyRepository>();
            //Bind<IEstadoCivilReadOnlyRepository>().To<EstadoCivilReadOnlyRepository>(); -- a implementar

            // Data Config ()
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}