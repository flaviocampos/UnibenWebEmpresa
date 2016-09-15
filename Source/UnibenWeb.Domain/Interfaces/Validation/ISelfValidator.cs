using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid();
    }
}