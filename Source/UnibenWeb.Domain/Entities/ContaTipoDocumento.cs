using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnibenWeb.Domain.Interfaces.Validation;
using UnibenWeb.Domain.Validation.ContaTipoDocumentos;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Entities
{
    [Table("ContaTipoDocumentos")]
    public class ContaTipoDocumento : ISelfValidator
    {
        public ContaTipoDocumento()
        {

        }

        [Key]
        public int ContaTipoDocumentoId { get; set; }
        public string Descricao { get; set; }

        public ValueObjects.ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid()
        {
            var fiscal = new ContaTipoDocumentoFiscalizarRegras();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
