using System.Threading;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Specification;
using UnibenWeb.Domain.Specification.Pessoa;
using UnibenWeb.Domain.Validation.Base;

namespace UnibenWeb.Domain.Validation.Pessoas
{
    public class PessoaEstaAptaParaEntrarNoSistema : FiscalBase<Pessoa>
    {
        public PessoaEstaAptaParaEntrarNoSistema()
        {
            var pessoaEndereco = new PessoaPossuiEndereco();
            var pessoaAtiva = new PessoaPossuiStatusAtivo();
            var pessoaCPFValido = new PessoaPossuiCPFValido();
            var pessoaMenorIdade = new PessoaMenorIdade();
            var pessoaDataMaiorQueDataAgora = new PessoaDataMaiorQueDataAgora();

            //base.AdicionarRegra("pessoaEndereco", new Regra<Pessoa>(pessoaEndereco, "Pessoa não possui endereço cadastrado!"));
            //base.AdicionarRegra("pessoaAtiva", new Regra<Pessoa>(pessoaAtiva, "Pessoa não está ativa!"));
            //base.AdicionarRegra("pessoaCPFValido", new Regra<Pessoa>(pessoaCPFValido, "Pessoa não possui um CPF válido!"));
            //base.AdicionarRegra("pessoaMenorIdade", new Regra<Pessoa>(pessoaMenorIdade, "Pessoa não é maior de 18 anos!"));
            //base.AdicionarRegra("pessoaDataMaiorQueDataAgora", new Regra<Pessoa>(pessoaDataMaiorQueDataAgora, "A data de nascimento não é menor que a data atual!"));
        }

    }
}