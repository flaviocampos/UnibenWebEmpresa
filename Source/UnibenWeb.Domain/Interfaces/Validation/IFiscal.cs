using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Validation
{
    interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
