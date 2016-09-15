using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnibenWeb.Domain.Interfaces.Validation;
using UnibenWeb.Domain.Validation.Enderecos;
using ValidationResult = UnibenWeb.Domain.ValueObjects.ValidationResult;

namespace UnibenWeb.Domain.Entities
{
    [Table("Enderecos")]
    public class Endereco : ISelfValidator
    {

        public Endereco()
        {
            //EnderecoId = Guid.NewGuid();
        }
        [Key]

        public int EnderecoId { get; set; }
        public int TipoEnderecoId { get; set; } // fk
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid()
        {
            var fiscal = new EnderecoValidacaoGeral();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }

    }
}
