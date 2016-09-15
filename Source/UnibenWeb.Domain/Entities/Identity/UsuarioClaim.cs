using System;

namespace UnibenWeb.Domain.Entities.Identity
{
    public class UsuarioClaim
    {
        public UsuarioClaim()
        {
            Id = Guid.NewGuid();
        }

        //[Key]
        public Guid Id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Fornceça um nome para a Claim")]
        //[MaxLength(128, ErrorMessage = "Tamanho máximo {0} excedido")]
        //[Display(Name = "Nome da Claim")]
        public string Name { get; set; }
    }
}