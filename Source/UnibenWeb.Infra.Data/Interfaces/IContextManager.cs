using UnibenWeb.Infra.CrossCutting.Audit.Context;
using UnibenWeb.Infra.Data.Context;

namespace UnibenWeb.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        UnibenContext GetContext();
        UnibenLogContext GetContextLog();
        FirebirdContext GetFbContext();
    }
}