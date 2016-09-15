using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnibenWeb.Domain.Interfaces.Validation;
using UnibenWeb.Domain.Validation.UnidadesNegocio;

namespace UnibenWeb.Domain.Entities
{
    [Table("UnidadesNegocio")]
    public class UnidadeNegocio : ISelfValidator
    {
        public UnidadeNegocio()
        {

        }
        [Key]
        public int UnidadeNegocioId { get; set; }
        public string Descricao { get; set; }

        public ValueObjects.ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid()
        {
            var fiscal = new UnidadeNegocioFiscalizarRegras();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }
    }

}
