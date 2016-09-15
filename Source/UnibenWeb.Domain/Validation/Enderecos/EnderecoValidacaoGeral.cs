using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Specification.Endereco;
using UnibenWeb.Domain.Validation.Base;

namespace UnibenWeb.Domain.Validation.Enderecos
{
    public class EnderecoValidacaoGeral : FiscalBase<Endereco>
    {
        public EnderecoValidacaoGeral()
        {
            //var valEnd = new EnderecoValidar();
            //base.AdicionarRegra("pessoaEndereco", new Regra<Endereco>(valEnd, "Endereço não está válido!"));
        }
    }
}