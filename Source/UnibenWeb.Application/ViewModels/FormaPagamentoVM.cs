using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public enum FormaPagamentoVM
    {
        [Display(Name = "Cartão de Débito")]
        CD = 0x1,
        [Display(Name = "Cartão de Crédito")]
        CC = 0x2,
        [Display(Name = "Débito Automático")]
        DA = 0x4,
        [Display(Name = "Boleto Bancário")]
        BB = 0x8,
        [Display(Name = "Em Dinheiro")]
        Di = 0x16
    }
}