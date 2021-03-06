﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Application.AutoMapper
{
    public class DomainToVMMappingProfile : Profile
    {
        
        public override string ProfileName
        {
            get { return "DomainToVMMappings"; }
        }
        
        protected override void Configure()
        {
            //CreateMap<Pessoa, PessoaVM>().ForMember(dst=>dst.Sexo, pt=>pt.MapFrom(src=>src.SexoId));
            CreateMap<Banco, BancoVm>();
            // Para utilizar quando os campos do mapeamento nao batem:
            // .ForMember(dest => dest.Enderecos, pt => pt.MapFrom(src => src.EnderecoList));
        }
    }

}
