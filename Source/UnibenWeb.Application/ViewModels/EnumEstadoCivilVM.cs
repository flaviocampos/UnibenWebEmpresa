using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public enum EnumEstadoCivilVM
    {
        [Display(Name = "Casado(a)")]
        C = 0x1,
        [Display(Name = "Solteiro(a)")]
        S = 0x2,
        [Display(Name = "Divorciado(a)")]
        D = 0x4,
        [Display(Name = "União Estável")]
        U = 0x8,
        [Display(Name = "Viuvo(a)")]
        V = 0x16
    }
}