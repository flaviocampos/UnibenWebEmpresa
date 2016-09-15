using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public enum GrauParentescoVM
    {
        [Display(Name = "Companheiro(a)")]
        Comp = 0x1,
        [Display(Name = "Cunhado(a)")]
        Cunh = 0x2,
        [Display(Name = "Enteado(a)")]
        Ente = 0x3,
        [Display(Name = "Esposo(a)")]
        Espo = 0x4,
        [Display(Name = "Filho(a)")]
        Filh = 0x5,
        [Display(Name = "Genro")]
        Genr = 0x6,
        [Display(Name = "Irmã")]
        Irma = 0x7,
        [Display(Name = "Irmão")]
        Irmo = 0x8,
        [Display(Name = "Madrasta")]
        Madr = 0x9,
        [Display(Name = "Mãe")]
        Mae = 0x10,
        [Display(Name = "Neto(a)")]
        Neto = 0x11,
        [Display(Name = "Nora")]
        Nora = 0x12,
        [Display(Name = "Padrasto")]
        Padr = 0x13,
        [Display(Name = "Pai")]
        Pai = 0x14,
        [Display(Name = "Primo(a)")]
        Prio = 0x15,
        [Display(Name = "Sobrinho(a)")]
        Sobr = 0x16,
        [Display(Name = "Sogro(a)")]
        Sogr = 0x17,
        [Display(Name = "Tio(a)")]
        Tio = 0x18
    }
}