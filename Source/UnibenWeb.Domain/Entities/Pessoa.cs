using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using UnibenWeb.Domain.Interfaces.Validation;
using UnibenWeb.Domain.Validation.Pessoas;
using ValidationResult = UnibenWeb.Domain.ValueObjects.ValidationResult;

namespace UnibenWeb.Domain.Entities
{
    [Table("Pessoas")]
    public class Pessoa : ISelfValidator
    {
        public Pessoa()
        {
           // PessoaId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
            Telefones = new List<TelContato>();
        }

        [Key]
        public int PessoaId { get; set; }
        //public int PessoaTipoId { get; set; }
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; } // data inscricao empresa
        public string CPF_CNPJ { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissorId { get; set; } // FK
        public string NomeMae { get; set; } 
        public string NomePai { get; set; }
        public int NaturalidadeId { get; set; } // FK
        public int NacionalidadeId { get; set; } // FK
        public string CartaoSUS { get; set; }
        public string PISPASEP { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public bool Ativo { get; set; }

        public int? SexoId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int BancoId { get; set; }
        public int PessoaTipoId { get; set; }

        public virtual PessoaSexo Sexo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        public virtual Banco Banco { get; set; }
        public virtual PessoaTipo PessoaTipo { get; set; }

        public virtual ICollection<TelContato> Telefones { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        /* Virtual: utiliza (habilitado por padrao) o lazy loading através (Aspnet) de override da função de query dos objetos no banco */

        public ValidationResult ResultadoValidacao { get; set; }

        public bool IsValid()
        {
            var fiscal = new PessoaEstaAptaParaEntrarNoSistema();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }
    }
}