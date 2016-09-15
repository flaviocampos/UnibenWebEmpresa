using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BoletoNet;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.Data.Repositories;
using UnibenWeb.Infra.Data.Repositories.ReadOnly;
using Banco = UnibenWeb.Domain.Entities.Banco;
using System.Web.Mvc;

namespace UnibenWeb.Application
{
    public class BancoAppService : IBancoAppService
    {
        private readonly BancoRepository _bancoRepository = new BancoRepository();
        private readonly BancoReadOnlyRepository _bancoReadOnlyRepository = new BancoReadOnlyRepository();

        public IEnumerable<BancoVM> BuscaComPesquisa(int skip, int take, string pesquisa)
        {
            var bancos = _bancoReadOnlyRepository.BuscaComPesquisa(0, 50, pesquisa);
            //return bancos;
            return Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoVM>>(bancos);
        }

        public IEnumerable<Banco> RetornaLista(int skip, int take, string pesquisa)
        {
            var bancos = _bancoReadOnlyRepository.BuscaComPesquisa(0, 50, pesquisa);
            return bancos;
        }

        public string BoletoImprimir() // List<BoletoBancario> boletos
        {
            var boletos = new List<BoletoBancario>();

            var vencimento = new DateTime(2016, 07, 16);

            var cedente = new Cedente("00.000.000/0000-00", "Empresa Teste", "0131", "7", "00045110", "X")
            {
                Codigo = "1220950",
                Convenio = 1234567
            };

            var boleto = new Boleto(vencimento, Convert.ToDecimal(1.99), "17", "10028528", cedente);

            boleto.Sacado = new Sacado("000.000.000-00","Nome do cliente ");
            boleto.Sacado.Endereco.End = "Endereco do cliente";
            boleto.Sacado.Endereco.Bairro = "Bairro do cliente";
            boleto.Sacado.Endereco.Cidade = "Cidade do cliente";
            boleto.Sacado.Endereco.CEP = "00000000";
            boleto.Sacado.Endereco.UF = "UF";

            // instrucoes do boleto
            Instrucao_Caixa item;
            item = new Instrucao_Caixa((int)10,Convert.ToDecimal(0.40));
            boleto.Instrucoes.Add(item);

            // documento
            boleto.NumeroDocumento = "10028528"; // nosso número

            EspecieDocumento_BancoBrasil espDocBB = new EspecieDocumento_BancoBrasil();
            boleto.EspecieDocumento = new EspecieDocumento_BancoBrasil(
                espDocBB.getCodigoEspecieByEnum(EnumEspecieDocumento_BancoBrasil.Outros));

            boleto.DataProcessamento = DateTime.Now;
            boleto.DataDocumento = DateTime.Now;

            var boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = 1;
            //boletoBancario.CodigoBanco = 104; // CEF
            //boletoBancario.CodigoBanco = 33; // SANTANDER
            boletoBancario.Boleto = boleto;

            boletoBancario.GeraImagemCodigoBarras(boleto);

            boletoBancario.MostrarComprovanteEntrega = true;

            boletoBancario.Boleto.Valida();

            boletos.Add(boletoBancario);

            var _arquivo = string.Empty;
            var html = new StringBuilder();

            _arquivo = "C:/Users/correa/Documents/text.html";


            foreach (var o in boletos)
            {
                html.Append(o.MontaHtmlEmbedded());
                html.Append("</br></br></br></br></br></br></br></br>");
            }

                using (var f = new FileStream(_arquivo, FileMode.Create))
                {
                    StreamWriter w = new StreamWriter(f, System.Text.Encoding.UTF8);
                    //w.Write(html.ToString());
                    w.Write(html.ToString());
            }

            html = html
                //.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], "\\") // convertendo o caminho absoluto para relativo
                //.Replace(System.IO.Path.GetTempPath(), Url.Action("Temporario", "Faturas") + "/?filename=") // convertendo o caminho temporário em relativo
                //.Replace(".w666{width:666px}", ".w666{width:21cm}")
                //.Replace("<body>", "<body style=\"height:29cm\">")
                //.Replace("</html>", "<a length=\"0\" href=\"/Faturas/PrintBoleto?Fatura=subsFatura\" >Exportar PDF</a></html>")
                .Replace("</html>", "<a length=\"0\" href=\"#\" onclick=\"window.print();\">Imprimir</a></html>")
                //.Replace("subsFatura", Fatura.Replace("/", "%2F"))
                //.Replace("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">", "")
                //.Replace("Imprimir em impressora jato de tinta (ink jet) ou laser em qualidade normal. (Não use modo econômico).<br>Utilize folha A4 (210 x 297 mm) ou Carta (216 x 279 mm) - Corte na linha indicada<br>","")
                //.Replace("&nbsp;","")
            ;

            //var pg = MvcHtmlString.Create(html.ToString());
            return html.ToString();
            //return pg.ToHtmlString();
        }

        public SelectList ListasDeSelecao()
        {
            var listaBancos = BuscaComPesquisa(0, 999, null); //ViewBag.Bancos = new SelectList(listaBancos, "BancoId", "Nome");
            return new SelectList(listaBancos, "BancoId", "Nome");
        }

        public void Dispose()
        {
            _bancoRepository.Dispose();
        }
    }
}
