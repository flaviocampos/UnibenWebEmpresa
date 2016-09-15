using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace UnibenWeb.Application.ViewModels
{
    //[JsonConverter(typeof(StringEnumConverter))]
    //[Flags()]
    public enum EnumSexoVM
    {
    //[Display(Name = "Não Informado")]
    //NI=0x1,
    [Display(Name = "Feminino")] F=1,
    [Display(Name = "Masculino")] M=2
    }
}