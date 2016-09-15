using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnibenWeb.Domain.Entities
{
    [Table("EstadoCivis")]
    public class EstadoCivil
    {

        public EstadoCivil()
        {
            //Pessoas = new List<Pessoa>();
        } 
        [Key]
        public int EstadoCivilId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }

        //public virtual ICollection<Pessoa> Pessoas { get; set; }

    }
}
