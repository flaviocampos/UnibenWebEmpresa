using System;
using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class EstadoCivilVM
    {
        [Key]
        public int EstadoCivilId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public int Id_usuario_inclusao { get; set; }
        public int Id_usuario_alteracao { get; set; }
        public DateTime Data_inclusao { get; set; }
        public DateTime Data_alteracao { get; set; }
    }
}