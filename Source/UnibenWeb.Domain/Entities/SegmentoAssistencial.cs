using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    [Table("SegmentoAssistenciais")]
    public class SegmentoAssistencial
    {
        public SegmentoAssistencial()
        {

        }

        [Key]
        public int SegmentoAssistencialId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        /*
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public int Id_usuario_inclusao { get; set; }
        public int Id_usuario_alteracao { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime Data_alteracao { get; set; }
        */
    }
}
