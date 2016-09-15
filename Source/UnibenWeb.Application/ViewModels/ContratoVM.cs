using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Application.ViewModels
{
    public class ContratoVM
    {
        public ContratoVM()
        {

        }

        [Key]
        public int ContratoId { get; set; }
        public ModoPagamento ModoPagamento { get; set; }
        public Pessoa Entidade { get; set; }
        public Pessoa Consultor { get; set; }
        public IEnumerable<Observacao> Observacoes { get; set; }
        public IEnumerable<Pessoa> Beneficiarios { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
    }
