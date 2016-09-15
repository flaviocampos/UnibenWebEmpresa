using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public enum AbrangenciaGeograficaPlanoVM
    {
        [Display(Name = "Municipal")]
        M = 0x1,
        [Display(Name = "Estadual")]
        E = 0x2,
        [Display(Name = "Local")]
        L = 0x4,
        [Display(Name = "Nacional")]
        N = 0x8,
        [Display(Name = "Regional")]
        R = 0x16
    }
}