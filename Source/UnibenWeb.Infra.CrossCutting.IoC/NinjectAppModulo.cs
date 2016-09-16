using Ninject.Modules;
using UnibenWeb.Application;
using UnibenWeb.Application.Interface;

namespace UnibenWeb.Infra.CrossCutting.IoC
{
    public class NinjectAppModulo: NinjectModule
    {
        public override void Load()
        {
            // Application
            Bind<IBancoAppService>().To<BancoAppService>();
            Bind<IBaseAppService>().To<BaseAppService>();
            Bind<IBaseFbAppService>().To<BaseFbAppService>();

        }
    }
}