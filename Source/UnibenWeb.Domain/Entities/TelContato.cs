using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    [Table("TelContatos")]
    public class TelContato
    {
        public TelContato()
        {
            //Pessoa = new Pessoa();
        }
        [Key]
        public int TelContatoId { get; set; }
        public int Descricao { get; set; }
        public int Telefone { get; set; }
        public bool EnviarSMS { get; set; }

        //public int PessoaId

        //public Pessoa Pessoa { get; set; }

    }
}
