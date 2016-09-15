using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    [Table("Observacoes")]
    public class Observacao
    {
        public Observacao()
        {
        }

        [Key]
        public int ObservacaoId { get; set; }
        public string Descricao { get; set; }
    }
}
