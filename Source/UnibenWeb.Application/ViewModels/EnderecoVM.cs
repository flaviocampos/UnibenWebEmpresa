using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Application.ViewModels
{
    public class EnderecoVM
    {

        public EnderecoVM()
        {
            //EnderecoId = Guid.NewGuid();
        }

        [Key]
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int PessoaId { get; set; }
        // public virtual PessoaVM Pessoa { get; set; }

    }
}
