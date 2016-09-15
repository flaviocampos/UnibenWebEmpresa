﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IComunicacaoPessoaService: IDisposable
    {
        int Adicionar(ComunicacaoPessoa comunicacaoPessoa);
    }
}
